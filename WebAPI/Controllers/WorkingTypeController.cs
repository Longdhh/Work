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
    [RoutePrefix("api/working-type")]
    public class workingTypeController : ApiControllerBase
    {
        private IWorkingTypeService _workingTypeService;

        public workingTypeController(IErrorService errorService, IWorkingTypeService workingTypeService) : base(errorService)
        {
            this._workingTypeService = workingTypeService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listworkingType = _workingTypeService.GetAll();
                var listworkingTypeVm = Mapper.Map<List<WorkingTypeViewModel>>(listworkingType);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listworkingTypeVm);
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
                var model = _workingTypeService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.created_by).Skip(page - 1 * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<WorkingType>, List<WorkingTypeViewModel>>(query);

                var paginationSet = new PaginationSet<WorkingTypeViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, WorkingTypeViewModel workingTypeVm)
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
                    WorkingType newWorkingType = new WorkingType();
                    newWorkingType.UpdateWorkingType(workingTypeVm);
                    newWorkingType.created_at = DateTime.Now;
                    var workingType_obj = _workingTypeService.Add(newWorkingType);
                    _workingTypeService.SaveChanges();
                    var responseData = Mapper.Map<WorkingType, WorkingTypeViewModel>(newWorkingType);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, WorkingTypeViewModel workingTypeVm)
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
                    var workingTypeDb = _workingTypeService.getById(workingTypeVm.working_type_id);
                    workingTypeDb.UpdateWorkingType(workingTypeVm);
                    workingTypeDb.modified_at = DateTime.Now;
                    _workingTypeService.Update(workingTypeDb);
                    _workingTypeService.SaveChanges();
                    var responseData = Mapper.Map<WorkingType, WorkingTypeViewModel>(workingTypeDb);
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
                    var oldWorkingType = _workingTypeService.Delete(id);
                    _workingTypeService.SaveChanges();
                    var responseData = Mapper.Map<WorkingType, WorkingTypeViewModel>(oldWorkingType);
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
                var model = _workingTypeService.getById(id);

                var responseData = Mapper.Map<WorkingType, WorkingTypeViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}