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
    [RoutePrefix("api/salary-range")]
    public class SalaryRangeController : ApiControllerBase
    {
        private ISalaryRangeService _salaryRangeService;

        public SalaryRangeController(IErrorService errorService, ISalaryRangeService salaryRangeService) : base(errorService)
        {
            this._salaryRangeService = salaryRangeService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listSalaryRange = _salaryRangeService.GetAll();
                var listSalaryRangeVm = Mapper.Map<List<SalaryRangeViewModel>>(listSalaryRange);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listSalaryRangeVm);
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
                var model = _salaryRangeService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.created_by).Skip(page - 1 * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<SalaryRange>, List<SalaryRangeViewModel>>(query);

                var paginationSet = new PaginationSet<SalaryRangeViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, SalaryRangeViewModel salaryRangeVm)
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
                    SalaryRange newSalaryRange = new SalaryRange();
                    newSalaryRange.UpdateSalaryRange(salaryRangeVm);
                    newSalaryRange.created_at = DateTime.Now;
                    var salaryRange_obj = _salaryRangeService.Add(newSalaryRange);
                    _salaryRangeService.SaveChanges();
                    var responseData = Mapper.Map<SalaryRange, SalaryRangeViewModel>(newSalaryRange);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, SalaryRangeViewModel salaryRangeVm)
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
                    var salaryRangeDb = _salaryRangeService.getById(salaryRangeVm.salary_range_id);
                    salaryRangeDb.UpdateSalaryRange(salaryRangeVm);
                    salaryRangeDb.created_at = DateTime.Now;
                    _salaryRangeService.Update(salaryRangeDb);
                    _salaryRangeService.SaveChanges();
                    var responseData = Mapper.Map<SalaryRange, SalaryRangeViewModel>(salaryRangeDb);
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
                    var oldSalaryRange = _salaryRangeService.Delete(id);
                    _salaryRangeService.SaveChanges();
                    var responseData = Mapper.Map<SalaryRange, SalaryRangeViewModel>(oldSalaryRange);
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
                var model = _salaryRangeService.getById(id);

                var responseData = Mapper.Map<SalaryRange, SalaryRangeViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}