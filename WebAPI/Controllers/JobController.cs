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
    [RoutePrefix("api/job")]
    public class JobController : ApiControllerBase
    {
        private IJobService _jobService;

        public JobController(IErrorService errorService, IJobService jobService) : base(errorService)
        {
            this._jobService = jobService;
        }
        [Route("get-all-active")]
        public HttpResponseMessage GetActive(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listJob = _jobService.GetActive();
                var listJobVm = Mapper.Map<List<JobViewModel>>(listJob);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listJobVm);
                return response;
            });
        }
        [Route("get-all-pending-and-active-paging")]
        [HttpGet]
        public HttpResponseMessage GetAllPendingAndActive(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _jobService.GetAllActiveAndPending(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.created_at).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Job>, List<JobViewModel>>(query);

                var paginationSet = new PaginationSet<JobViewModel>()
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
                var model = _jobService.GetAllActive(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.job_end_date).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Job>, List<JobViewModel>>(query);

                var paginationSet = new PaginationSet<JobViewModel>()
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
        [Route("get-all-paging-by-company-id/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetAllByCompanyId(HttpRequestMessage request, string id, int page, int pageSize = 20)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _jobService.GetAllByCompanyId(id);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.created_at).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Job>, List<JobViewModel>>(query);

                var paginationSet = new PaginationSet<JobViewModel>()
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
        [Route("get-all-active-by-company-id/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetAllActiveByCompanyId(HttpRequestMessage request, string id, int page, int pageSize = 20)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _jobService.GetAllActiveByCompanyId(id);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.created_at).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Job>, List<JobViewModel>>(query);

                var paginationSet = new PaginationSet<JobViewModel>()
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
        [Route("get-all-registed-paging-by-job-id/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetAllRegistedByJobId(HttpRequestMessage request, int id, int page, int pageSize = 20)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _jobService.GetAllRegistedByJobId(id);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.created_at).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<JobUser>, List<JobUserViewModel>>(query);

                var paginationSet = new PaginationSet<JobUserViewModel>()
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
        [Route("get-all-registed-paging-by-user-id/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetAllRegistedByUserId(HttpRequestMessage request, string id, int page, int pageSize = 20)
        {
            return createHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _jobService.GetAllRegistedByUserId(id);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.created_at).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<JobUser>, List<JobUserViewModel>>(query);

                var paginationSet = new PaginationSet<JobUserViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, JobViewModel jobVm)
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
                    Job newJob = new Job();
                    List<JobCategory> jobCategories = new List<JobCategory>();
                    List<Welfare> welfares = new List<Welfare>();
                    newJob.UpdateJob(jobVm);
                    newJob.created_at = DateTime.Now;
                    newJob.job_view_count = 0;
                    newJob.status = "Inactive";
                    foreach (var item in jobVm.job_categories)
                    {
                        var jobCategory = new JobCategory();
                        jobCategory.category_id = item.category_id;
                        jobCategories.Add(jobCategory);
                    }
                    foreach (var item in jobVm.welfares)
                    {
                        var welfare = new Welfare();
                        welfare.welfare_type_id = item.welfare_type.welfare_type_id;
                        welfare.description = item.description;
                        welfares.Add(welfare);
                    }
                    var Job_obj = _jobService.Add(newJob, jobCategories, welfares);
                    _jobService.SaveChanges();
                    var responseData = Mapper.Map<Job, JobViewModel>(newJob);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("register-job")]
        [HttpPost]
        public HttpResponseMessage RegisterJob(HttpRequestMessage request, JobUserViewModel jobUserVm)
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
                    JobUser newJobUser = new JobUser();
                    newJobUser.UpdateJobUser(jobUserVm);
                    newJobUser.created_at = DateTime.Now;
                    _jobService.RegisterJob(newJobUser);
                    _jobService.SaveChanges();
                    var responseData = Mapper.Map<JobUser, JobUserViewModel>(newJobUser);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
        [Route("unregister-job")]
        [HttpDelete]
        public HttpResponseMessage UnregisterJob(HttpRequestMessage request, int id)
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
                    var oldJobUser = _jobService.UnregisterJob(id);
                    _jobService.SaveChanges();
                    var responseData = Mapper.Map<JobUser, JobUserViewModel>(oldJobUser);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, JobViewModel jobVm)
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
                    var jobDb = _jobService.getById(jobVm.job_id);
                    jobDb.UpdateJob(jobVm);
                    jobDb.modified_at = DateTime.Now;
                    List<JobCategory> jobCategories = new List<JobCategory>();
                    List<Welfare> welfares = new List<Welfare>();
                    foreach (var item in jobVm.job_categories)
                    {
                        var jobCategory = new JobCategory();
                        jobCategory.category_id = item.category_id;
                        jobCategory.job_id = jobVm.job_id;
                        jobCategories.Add(jobCategory);
                    }
                    foreach (var item in jobVm.welfares)
                    {
                        var welfare = new Welfare();
                        welfare.welfare_type_id = item.welfare_type.welfare_type_id;
                        welfare.description = item.description;
                        welfare.job_id = jobVm.job_id;
                        welfares.Add(welfare);
                    }

                    _jobService.Update(jobDb, jobCategories, welfares);
                    _jobService.SaveChanges();
                    var responseData = Mapper.Map<Job, JobViewModel>(jobDb);
                    response = request.CreateResponse(HttpStatusCode.Created, jobCategories);
                }
                return response;
            });
        }

        [HttpPut]
        [Route("send-job")]
        public HttpResponseMessage SendJob(HttpRequestMessage request, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _jobService.SendJob(id);
                    _jobService.SaveChanges();
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

        [HttpPut]
        [Route("public-job")]
        public HttpResponseMessage PublicJob(HttpRequestMessage request, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _jobService.PublicJob(id);
                    _jobService.SaveChanges();
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
        [HttpPut]
        [Route("unpublic-job")]
        public HttpResponseMessage UnpublicJob(HttpRequestMessage request, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _jobService.UnpublicJob(id);
                    _jobService.SaveChanges();
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
        [HttpPut]
        [Route("update-registed-count")]
        public HttpResponseMessage UpdateRegistedCount(HttpRequestMessage request, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _jobService.UpdateRegistedCount(id);
                    _jobService.SaveChanges();
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
                    var oldJob = _jobService.Delete(id);
                    _jobService.SaveChanges();
                    var responseData = Mapper.Map<Job, JobViewModel>(oldJob);
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
                var model = _jobService.getById(id);

                var responseData = Mapper.Map<Job, JobViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("get-categories/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCategories(HttpRequestMessage request, int id)
        {
            if (id == 0)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var jobCategories = _jobService.GetJobCategories(id);
            if (jobCategories == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var detailVms = Mapper.Map<List<JobCategory>, List<JobCategoryViewModel>>(jobCategories);

                return request.CreateResponse(HttpStatusCode.OK, detailVms);
            }
        }

        [Route("get-welfares/{id}")]
        [HttpGet]
        public HttpResponseMessage GetWelfares(HttpRequestMessage request, int id)
        {
            if (id == 0)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var welfares = _jobService.GetWelfares(id);
            if (welfares == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var detailVms = Mapper.Map<List<Welfare>, List<WelfareViewModel>>(welfares);

                return request.CreateResponse(HttpStatusCode.OK, detailVms);
            }
        }
    }
}