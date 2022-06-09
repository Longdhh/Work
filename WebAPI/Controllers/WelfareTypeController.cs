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
    [RoutePrefix("api/welfare-type")]
    public class WelfareTypeController : ApiControllerBase
    {
        private IWelfareTypeService _welfareTypeService;

        public WelfareTypeController(IErrorService errorService, IWelfareTypeService welfareTypeService) : base(errorService)
        {
            this._welfareTypeService = welfareTypeService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listWelfareType = _welfareTypeService.GetAll();
                var listWelfareTypeVm = Mapper.Map<List<WelfareTypeViewModel>>(listWelfareType);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listWelfareTypeVm);
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
                var model = _welfareTypeService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.created_by).Skip(page - 1 * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<WelfareType>, List<WelfareTypeViewModel>>(query);

                var paginationSet = new PaginationSet<WelfareTypeViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, WelfareTypeViewModel welfareTypeVm)
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
                    WelfareType newWelfareType = new WelfareType();
                    newWelfareType.UpdateWelfareType(welfareTypeVm);
                    newWelfareType.created_at = DateTime.Now;
                    var welfareType_obj = _welfareTypeService.Add(newWelfareType);
                    _welfareTypeService.SaveChanges();
                    var responseData = Mapper.Map<WelfareType, WelfareTypeViewModel>(newWelfareType);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, WelfareTypeViewModel welfareTypeVm)
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
                    var welfareTypeDb = _welfareTypeService.getById(welfareTypeVm.welfare_type_id);
                    welfareTypeDb.UpdateWelfareType(welfareTypeVm);
                    welfareTypeDb.modified_at = DateTime.Now;
                    _welfareTypeService.Update(welfareTypeDb);
                    _welfareTypeService.SaveChanges();
                    var responseData = Mapper.Map<WelfareType, WelfareTypeViewModel>(welfareTypeDb);
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
                    var oldWelfareType = _welfareTypeService.Delete(id);
                    _welfareTypeService.SaveChanges();
                    var responseData = Mapper.Map<WelfareType, WelfareTypeViewModel>(oldWelfareType);
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
                var model = _welfareTypeService.getById(id);

                var responseData = Mapper.Map<WelfareType, WelfareTypeViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}