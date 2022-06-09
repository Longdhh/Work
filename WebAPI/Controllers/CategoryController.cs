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
    [RoutePrefix("api/category")]
    public class CategoryController : ApiControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(IErrorService errorService, ICategoryService categoryService) : base(errorService)
        {
            this._categoryService = categoryService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listCategory = _categoryService.GetAll();
                var listCategoryVm = Mapper.Map<List<CategoryViewModel>>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategoryVm);
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
                var model = _categoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.created_by).Skip(page - 1 * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Category>, List<CategoryViewModel>>(query);

                var paginationSet = new PaginationSet<CategoryViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, CategoryViewModel categoryVm)
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
                    Category newCategory = new Category();
                    newCategory.UpdateCategory(categoryVm);
                    newCategory.created_at = DateTime.Now;
                    var category_obj = _categoryService.Add(newCategory);
                    _categoryService.SaveChanges();
                    var responseData = Mapper.Map<Category, CategoryViewModel>(newCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, CategoryViewModel categoryVm)
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
                    var categoryDb = _categoryService.getById(categoryVm.category_id);
                    categoryDb.UpdateCategory(categoryVm);
                    categoryDb.modified_at = DateTime.Now;
                    _categoryService.Update(categoryDb);
                    _categoryService.SaveChanges();
                    var responseData = Mapper.Map<Category, CategoryViewModel>(categoryDb);
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
                    var oldCategory = _categoryService.Delete(id);
                    _categoryService.SaveChanges();
                    var responseData = Mapper.Map<Category, CategoryViewModel>(oldCategory);
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
                var model = _categoryService.getById(id);

                var responseData = Mapper.Map<Category, CategoryViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}