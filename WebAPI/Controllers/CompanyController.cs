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
    [RoutePrefix("api/company")]
    public class CompanyController : ApiControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(IErrorService errorService, ICompanyService companyService) : base(errorService)
        {
            this._companyService = companyService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listCompany = _companyService.GetAll();
                var listCompanyVm = Mapper.Map<List<CompanyViewModel>>(listCompany);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCompanyVm);
                return response;
            });
        }

        [Route("get-all-active")]
        public HttpResponseMessage GetActive(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listCompany = _companyService.GetActive();
                var listCompanyVm = Mapper.Map<List<CompanyViewModel>>(listCompany);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCompanyVm);
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
                var model = _companyService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Company>, List<CompanyViewModel>>(query);

                var paginationSet = new PaginationSet<CompanyViewModel>()
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
        [Route("get-all-active-paging")]
        [HttpGet]
        public HttpResponseMessage GetAllActive(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _companyService.GetAllActive(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.created_by).Skip(page - 1 * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Company>, List<CompanyViewModel>>(query);

                var paginationSet = new PaginationSet<CompanyViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, CompanyViewModel CompanyVm)
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
                    Company newCompany = new Company();
                    newCompany.UpdateCompany(CompanyVm);
                    newCompany.created_at = DateTime.Now;
                    newCompany.status = true;
                    var Company_obj = _companyService.Add(newCompany);
                    _companyService.SaveChanges();
                    var responseData = Mapper.Map<Company, CompanyViewModel>(newCompany);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, CompanyViewModel CompanyVm)
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
                    var CompanyDb = _companyService.getById(CompanyVm.Id);
                    CompanyDb.UpdateCompany(CompanyVm);
                    CompanyDb.modified_at = DateTime.Now;
                    _companyService.Update(CompanyDb);
                    _companyService.SaveChanges();
                    var responseData = Mapper.Map<Company, CompanyViewModel>(CompanyDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, string id)
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
                    var oldCompany = _companyService.Delete(id);
                    _companyService.SaveChanges();
                    var responseData = Mapper.Map<Company, CompanyViewModel>(oldCompany);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            return createHttpResponseMessage(request, () =>
            {
                var model = _companyService.getById(id);

                var responseData = Mapper.Map<Company, CompanyViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}