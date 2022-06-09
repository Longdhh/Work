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
    [RoutePrefix("api/province")]
    public class ProvinceController : ApiControllerBase
    {
        private IProvinceService _provinceService;

        public ProvinceController(IErrorService errorService, IProvinceService provinceService) : base(errorService)
        {
            this._provinceService = provinceService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listProvince = _provinceService.GetAll();
                var listProvinceVm = Mapper.Map<List<ProvinceViewModel>>(listProvince);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProvinceVm);
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
                var model = _provinceService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.created_by).Skip(page - 1 * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Province>, List<ProvinceViewModel>>(query);

                var paginationSet = new PaginationSet<ProvinceViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, ProvinceViewModel provinceVm)
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
                    Province newProvince = new Province();
                    newProvince.UpdateProvince(provinceVm);
                    newProvince.created_at = DateTime.Now;
                    var province_obj = _provinceService.Add(newProvince);
                    _provinceService.SaveChanges();
                    var responseData = Mapper.Map<Province, ProvinceViewModel>(newProvince);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, ProvinceViewModel provinceVm)
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
                    var provinceDb = _provinceService.getById(provinceVm.province_id);
                    provinceDb.UpdateProvince(provinceVm);
                    provinceDb.created_at = DateTime.Now;
                    _provinceService.Update(provinceDb);
                    _provinceService.SaveChanges();
                    var responseData = Mapper.Map<Province, ProvinceViewModel>(provinceDb);
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
                    var oldProvince = _provinceService.Delete(id);
                    _provinceService.SaveChanges();
                    var responseData = Mapper.Map<Province, ProvinceViewModel>(oldProvince);
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
                var model = _provinceService.getById(id);

                var responseData = Mapper.Map<Province, ProvinceViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}