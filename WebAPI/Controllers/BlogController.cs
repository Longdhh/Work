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
    [RoutePrefix("api/blog")]
    public class BlogController : ApiControllerBase
    {
        private IBlogService _blogService;

        public BlogController(IErrorService errorService, IBlogService blogService) : base(errorService)
        {
            this._blogService = blogService;
        }

        [Route("get-all")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listBlog = _blogService.GetAll();
                var listBlogVm = Mapper.Map<List<BlogViewModel>>(listBlog);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listBlogVm);
                return response;
            });
        }

        [Route("get-all-active")]
        [HttpGet]
        public HttpResponseMessage GetAllActive(HttpRequestMessage request, string keyword)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listBlog = _blogService.GetAllActive(keyword);
                var listBlogVm = Mapper.Map<List<BlogViewModel>>(listBlog);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listBlogVm);
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
                var model = _blogService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Blog>, List<BlogViewModel>>(query);

                var paginationSet = new PaginationSet<BlogViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, BlogViewModel BlogVm)
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
                    Blog newBlog = new Blog();
                    newBlog.UpdateBlog(BlogVm);
                    newBlog.created_at = DateTime.Now;
                    var Blog_obj = _blogService.Add(newBlog);
                    _blogService.SaveChanges();
                    var responseData = Mapper.Map<Blog, BlogViewModel>(newBlog);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, BlogViewModel blogVm)
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
                    var blogDb = _blogService.getById(blogVm.blog_id);
                    blogDb.UpdateBlog(blogVm);
                    blogDb.modified_at = DateTime.Now;
                    _blogService.Update(blogDb);
                    _blogService.SaveChanges();
                    var responseData = Mapper.Map<Blog, BlogViewModel>(blogDb);
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
                    var oldBlog = _blogService.Delete(id);
                    _blogService.SaveChanges();
                    var responseData = Mapper.Map<Blog, BlogViewModel>(oldBlog);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("status-change")]
        [HttpPut]
        public HttpResponseMessage Publish(HttpRequestMessage request, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _blogService.ChangeStatus(id);
                    _blogService.SaveChanges();
                    return request.CreateResponse(HttpStatusCode.OK, id);
                }
                catch (Exception dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, int id)
        {
            return createHttpResponseMessage(request, () =>
            {
                var model = _blogService.getById(id);

                var responseData = Mapper.Map<Blog, BlogViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}
