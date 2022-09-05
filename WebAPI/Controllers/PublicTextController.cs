using AutoMapper;
using System;
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
    [RoutePrefix("api/public-text")]
    public class PublicTextController : ApiControllerBase
    {
        private IPublicTextService _publicTextService;

        public PublicTextController(IErrorService errorService, IPublicTextService publicTextService) : base(errorService)
        {
            this._publicTextService = publicTextService;
        }

        [Route("get/{id}")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return createHttpResponseMessage(request, () =>
            {
                var model = _publicTextService.getById(id);

                var responseData = Mapper.Map<PublicText, PublicTextViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PublicTextViewModel publicTextVm)
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
                    var publicTextDb = _publicTextService.getById(publicTextVm.public_text_id);
                    publicTextDb.UpdatePublicText(publicTextVm);
                    publicTextDb.created_at = DateTime.Now;
                    _publicTextService.Update(publicTextDb);
                    _publicTextService.SaveChanges();
                    var responseData = Mapper.Map<PublicText, PublicTextViewModel>(publicTextDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
    }
}
