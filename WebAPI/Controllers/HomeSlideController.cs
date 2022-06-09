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
    [RoutePrefix("api/home-slide")]
    public class HomeSlideController : ApiControllerBase
    {
        private IHomeSlideService _homeSlideService;

        public HomeSlideController(IErrorService errorService, IHomeSlideService homeSlideService) : base(errorService)
        {
            this._homeSlideService = homeSlideService;
        }

        [Route("get-all-paging")]
        [HttpGet]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, string keyword, int page, int pageSize, string filter = null)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _homeSlideService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.created_by).Skip(page - 1 * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<HomeSlide>, List<HomeSlideViewModel>>(query);

                var paginationSet = new PaginationSet<HomeSlideViewModel>()
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

        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, int id)
        {
            return createHttpResponseMessage(request, () =>
            {
                var model = _homeSlideService.getById(id);

                var responseData = Mapper.Map<HomeSlide, HomeSlideViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, HomeSlideViewModel HomeSlideVm)
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
                    HomeSlide newHomeSlide = new HomeSlide();
                    newHomeSlide.UpdateHomeSlide(HomeSlideVm);
                    newHomeSlide.created_at = DateTime.Now;
                    var HomeSlide_obj = _homeSlideService.Add(newHomeSlide);
                    _homeSlideService.SaveChanges();
                    var responseData = Mapper.Map<HomeSlide, HomeSlideViewModel>(newHomeSlide);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, HomeSlideViewModel homeSlideVm)
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
                    var homeSlideDb = _homeSlideService.getById(homeSlideVm.home_slide_id);
                    homeSlideDb.UpdateHomeSlide(homeSlideVm);
                    homeSlideDb.modified_at = DateTime.Now;
                    _homeSlideService.Update(homeSlideDb);
                    _homeSlideService.SaveChanges();
                    var responseData = Mapper.Map<HomeSlide, HomeSlideViewModel>(homeSlideDb);
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
                    var oldhomeSlide = _homeSlideService.Delete(id);
                    _homeSlideService.SaveChanges();
                    var responseData = Mapper.Map<HomeSlide, HomeSlideViewModel>(oldhomeSlide);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}