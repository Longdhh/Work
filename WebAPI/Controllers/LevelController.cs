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
    [RoutePrefix("api/level")]
    public class LevelController : ApiControllerBase
    {
        private ILevelService _levelService;

        public LevelController(IErrorService errorService, ILevelService levelService) : base(errorService)
        {
            this._levelService = levelService;
        }

        [Route("get-all")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                var listLevel = _levelService.GetAll();
                var listLevelVm = Mapper.Map<List<LevelViewModel>>(listLevel);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listLevelVm);
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
                var model = _levelService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var responseData = Mapper.Map<List<Level>, List<LevelViewModel>>(query);

                var paginationSet = new PaginationSet<LevelViewModel>()
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
        public HttpResponseMessage Post(HttpRequestMessage request, LevelViewModel levelVm)
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
                    Level newLevel = new Level();
                    newLevel.UpdateLevel(levelVm);
                    newLevel.created_at = DateTime.Now;
                    var level_obj = _levelService.Add(newLevel);
                    _levelService.SaveChanges();
                    var responseData = Mapper.Map<Level, LevelViewModel>(newLevel);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, LevelViewModel levelVm)
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
                    var levelDb = _levelService.getById(levelVm.level_id);
                    levelDb.UpdateLevel(levelVm);
                    levelDb.modified_at = DateTime.Now;
                    _levelService.Update(levelDb);
                    _levelService.SaveChanges();
                    var responseData = Mapper.Map<Level, LevelViewModel>(levelDb);
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
                    var oldLevel = _levelService.Delete(id);
                    _levelService.SaveChanges();
                    var responseData = Mapper.Map<Level, LevelViewModel>(oldLevel);
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
                var model = _levelService.getById(id);

                var responseData = Mapper.Map<Level, LevelViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}