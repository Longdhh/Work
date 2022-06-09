using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Infrastructure.Core;
using WebAPI.Models;
using WebAPI.SignalR;
using Work.Model.Models;
using Work.Service;

namespace WebAPI.Controllers
{
    public class AnnouncementController : ApiControllerBase
    {
        private IAnnouncementService _announcementService;

        public AnnouncementController(IErrorService errorService,
            IAnnouncementService announcementService)
            : base(errorService)
        {
            _announcementService = announcementService;
        }

        [Route("get-top-my-announcement")]
        [HttpGet]
        public HttpResponseMessage GetTopMyAnnouncement(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                List<Announcement> model = _announcementService.ListAllUnread(User.Identity.GetUserId(), 1, 10, out totalRow);
                IEnumerable<AnnouncementViewModel> modelVm = Mapper.Map<List<Announcement>, List<AnnouncementViewModel>>(model);

                PaginationSet<AnnouncementViewModel> pagedSet = new PaginationSet<AnnouncementViewModel>()
                {
                    PageIndex = 1,
                    TotalRows = totalRow,
                    PageSize = 10,
                    Items = modelVm
                };
                response = request.CreateResponse(HttpStatusCode.OK, modelVm);

                return response;
            });
        }

        [Route("get-all")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int pageIndex, int pageSize)
        {
            return createHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = _announcementService.GetListAll(pageIndex, pageSize, out totalRow);

                IEnumerable<AnnouncementViewModel> modelVm = Mapper.Map<List<Announcement>, List<AnnouncementViewModel>>(model);
                PaginationSet<AnnouncementViewModel> pagedSet = new PaginationSet<AnnouncementViewModel>()
                {
                    PageIndex = pageIndex,
                    TotalRows = totalRow,
                    PageSize = pageSize,
                    Items = modelVm
                };
                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, int id)
        {
            if (id == 0)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var announcement = _announcementService.GetDetail(id);
            if (announcement == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");
            }
            var modelVm = Mapper.Map<Announcement, AnnouncementViewModel>(announcement);

            return request.CreateResponse(HttpStatusCode.OK, modelVm);
        }

        /*
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, AnnouncementViewModel announcementVm)
        {
            if (ModelState.IsValid)
            {
                var newAnnoun = new Announcement();
                try
                {
                    newAnnoun.content = announcementVm.content;
                    newAnnoun.status = announcementVm.status;
                    newAnnoun.title = announcementVm.title;
                    newAnnoun.email = announcementVm.email;
                    newAnnoun.phone_number = announcementVm.phone_number;
                    newAnnoun.created_at = DateTime.Now;
                    newAnnoun.resume = announcementVm.resume;
                    newAnnoun.Id = User.Identity.GetUserId();
                    foreach (var user in announcementVm.announcement_users)
                    {
                        newAnnoun.announcement_users.Add(new AnnouncementUser()
                        {
                            id = user.id,
                            has_read = false
                        });
                    }
                    _announcementService.Create(newAnnoun);
                    _announcementService.Save();

                    var announ = _announcementService.GetDetail(newAnnoun.announcement_id);
                    //push notification
                    WorkHub.PushToUser(Mapper.Map<Announcement, AnnouncementViewModel>(announ), null);

                    return request.CreateResponse(HttpStatusCode.OK, announcementVm);
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
        */

        [HttpPost]
        [Route("add-to-all-users")]
        public HttpResponseMessage AddToAll(HttpRequestMessage request, AnnouncementViewModel announcementVm)
        {
            if (ModelState.IsValid)
            {
                var newAnnoun = new Announcement();
                try
                {
                    newAnnoun.content = announcementVm.content;
                    newAnnoun.status = announcementVm.status;
                    newAnnoun.title = announcementVm.title;
                    newAnnoun.created_at = DateTime.Now;
                    newAnnoun.Id = User.Identity.GetUserId();
                    foreach (var user in announcementVm.announcement_users)
                    {
                        newAnnoun.announcement_users.Add(new AnnouncementUser()
                        {
                            id = user.id,
                            has_read = false
                        });
                    }
                    _announcementService.Create(newAnnoun);
                    _announcementService.Save();

                    var announ = _announcementService.GetDetail(newAnnoun.announcement_id);
                    //push notification
                    WorkHub.PushToAllUsers(Mapper.Map<Announcement, AnnouncementViewModel>(announ), null);

                    return request.CreateResponse(HttpStatusCode.OK, announcementVm);
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

        [HttpGet]
        [Route("mark-as-read")]
        public HttpResponseMessage MarkAsRead(HttpRequestMessage request, int announId)
        {
            try
            {
                _announcementService.MarkAsRead(User.Identity.GetUserId(), announId);
                _announcementService.Save();
                return request.CreateResponse(HttpStatusCode.OK, announId);
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            _announcementService.Delete(id);
            _announcementService.Save();

            return request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}