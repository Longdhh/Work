using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Infrastructure.Core;
using WebAPI.Infrastructure.Extensions;
using WebAPI.Models;
using Work.Model.Models;
using Work.Service;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/blog-category")]
    public class blogCategoryController : ApiControllerBase
    {
        private IBlogCategoryService _blogCategoryService;

        public blogCategoryController(IErrorService errorService, IBlogCategoryService blogCategoryService) : base(errorService)
        {
            this._blogCategoryService = blogCategoryService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listBlogCategory = _blogCategoryService.GetAll();
                var listBlogCategoryVm = Mapper.Map<List<BlogCategoryViewModel>>(listBlogCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listBlogCategoryVm);
                return response;
            });
        }

        [Route("get-all-paging")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _blogCategoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<BlogCategory>, List<BlogCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<BlogCategoryViewModel>()
                {
                    Items = responseData,
                    PageIndex = page,
                    TotalRows = totalRow,
                    PageSize = pageSize
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, BlogCategoryViewModel blogCategoryVm)
        {
            return createHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    BlogCategory newBlogCategory = new BlogCategory();
                    newBlogCategory.UpdateBlogCategory(blogCategoryVm);
                    newBlogCategory.created_at = DateTime.Now;
                    var blogCategory_obj = _blogCategoryService.Add(newBlogCategory);
                    _blogCategoryService.SaveChanges();
                    var responseData = Mapper.Map<BlogCategory, BlogCategoryViewModel>(newBlogCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, BlogCategoryViewModel blogCategoryVm)
        {
            return createHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var blogCategoryDb = _blogCategoryService.getById(blogCategoryVm.blog_category_id);
                    blogCategoryDb.UpdateBlogCategory(blogCategoryVm);
                    blogCategoryDb.modified_at = DateTime.Now;
                    _blogCategoryService.Update(blogCategoryDb);
                    _blogCategoryService.SaveChanges();
                    var responseData = Mapper.Map<BlogCategory, BlogCategoryViewModel>(blogCategoryDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return createHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldBlogCategory = _blogCategoryService.Delete(id);
                    _blogCategoryService.SaveChanges();
                    var responseData = Mapper.Map<BlogCategory, BlogCategoryViewModel>(oldBlogCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, int id)
        {
            return createHttpResponseMessage(request, () =>
            {
                var model = _blogCategoryService.getById(id);

                var responseData = Mapper.Map<BlogCategory, BlogCategoryViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}
