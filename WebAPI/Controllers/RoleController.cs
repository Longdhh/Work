using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Infrastructure.Core;
using WebAPI.Infrastructure.Extensions;
using WebAPI.Models;
using WebAPI.Models.DataContracts;
using Work.Common.Exceptions;
using Work.Model.Models;
using Work.Service;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/app-role")]
    public class AppRoleController : ApiControllerBase
    {
        private IPermissionService _permissionService;
        private IFunctionService _functionService;

        public AppRoleController(IErrorService errorService, IFunctionService functionService, IPermissionService permissionService) : base(errorService)
        {
            _functionService = functionService;
            _permissionService = permissionService;
        }

        [Route("get-list-paging")]
        [HttpGet]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {
            return createHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var query = AppRoleManager.Roles;
                if (!string.IsNullOrEmpty(filter))
                    query = query.Where(x => x.Description.Contains(filter));
                totalRow = query.Count();

                var model = query.OrderBy(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize);

                IEnumerable<ApplicationRoleViewModel> modelVm = Mapper.Map<IEnumerable<ApplicationRole>, IEnumerable<ApplicationRoleViewModel>>(model);

                PaginationSet<ApplicationRoleViewModel> pagedSet = new PaginationSet<ApplicationRoleViewModel>()
                {
                    PageIndex = page,
                    TotalRows = totalRow,
                    PageSize = pageSize,
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [Route("get-all")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return createHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                var model = AppRoleManager.Roles.ToList();
                IEnumerable<ApplicationRoleViewModel> modelVm = Mapper.Map<IEnumerable<ApplicationRole>, IEnumerable<ApplicationRoleViewModel>>(model);

                response = request.CreateResponse(HttpStatusCode.OK, modelVm);

                return response;
            });
        }

        [Route("get-all-permission")]
        [HttpGet]
        public HttpResponseMessage GetAllPermission(HttpRequestMessage request, string functionId)
        {
            return createHttpResponseMessage(request, () =>
            {
                List<PermissionViewModel> permissions = new List<PermissionViewModel>();
                HttpResponseMessage response = null;
                var roles = AppRoleManager.Roles.Where(x => x.Name != "Admin").ToList();
                var listPermission = _permissionService.GetByFunctionId(functionId).ToList();
                if (listPermission.Count == 0)
                {
                    foreach (var item in roles)
                    {
                        permissions.Add(new PermissionViewModel()
                        {
                            RoleId = item.Id,
                            CanCreate = false,
                            CanDelete = false,
                            CanRead = false,
                            CanUpdate = false,
                            AppRole = new ApplicationRoleViewModel()
                            {
                                Id = item.Id,
                                Name = item.Name
                            }
                        });
                    }
                }
                else
                {
                    foreach (var item in roles)
                    {
                        if (!listPermission.Any(x => x.RoleId == item.Id))
                        {
                            permissions.Add(new PermissionViewModel()
                            {
                                RoleId = item.Id,
                                CanCreate = false,
                                CanDelete = false,
                                CanRead = false,
                                CanUpdate = false,
                                AppRole = new ApplicationRoleViewModel()
                                {
                                    Id = item.Id,
                                    Name = item.Name
                                }
                            });
                        }
                        permissions = Mapper.Map<List<Permission>, List<PermissionViewModel>>(listPermission);
                    }
                }
                response = request.CreateResponse(HttpStatusCode.OK, permissions);

                return response;
            });
        }

        [HttpPost]
        [Route("save-permission")]
        public HttpResponseMessage SavePermission(HttpRequestMessage request, SavePermissionRequest data)
        {
            if (ModelState.IsValid)
            {
                _permissionService.DeleteAll(data.FunctionId);
                Permission permission = null;
                foreach (var item in data.Permissions)
                {
                    permission = new Permission();
                    permission.UpdatePermission(item);
                    permission.FunctionId = data.FunctionId;
                    _permissionService.Add(permission);
                }
                var functions = _functionService.GetAllWithParentID(data.FunctionId);
                if (functions.Any())
                {
                    foreach (var item in functions)
                    {
                        _permissionService.DeleteAll(item.ID);

                        foreach (var p in data.Permissions)
                        {
                            var childPermission = new Permission();
                            childPermission.FunctionId = item.ID;
                            childPermission.RoleId = p.RoleId;
                            childPermission.CanRead = p.CanRead;
                            childPermission.CanCreate = p.CanCreate;
                            childPermission.CanDelete = p.CanDelete;
                            childPermission.CanUpdate = p.CanUpdate;
                            _permissionService.Add(childPermission);
                        }
                    }
                }
                try
                {
                    _permissionService.SaveChange();
                    return request.CreateResponse(HttpStatusCode.OK, "Lưu quyền thành cống");
                }
                catch (Exception ex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            ApplicationRole appRole = AppRoleManager.FindByIdAsync(id).Result;
            if (appRole == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No group");
            }
            return request.CreateResponse(HttpStatusCode.OK, appRole);
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, ApplicationRoleViewModel applicationRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppRole = new ApplicationRole();
                newAppRole.UpdateApplicationRole(applicationRoleViewModel);
                try
                {
                    AppRoleManager.Create(newAppRole);
                    return request.CreateResponse(HttpStatusCode.OK, applicationRoleViewModel);
                }
                catch (NameDuplicatedException dex)
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
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ApplicationRoleViewModel applicationRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var appRole = AppRoleManager.FindByIdAsync(applicationRoleViewModel.Id).Result;
                try
                {
                    appRole.UpdateApplicationRole(applicationRoleViewModel, "update");
                    AppRoleManager.Update(appRole);
                    return request.CreateResponse(HttpStatusCode.OK, appRole);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, string id)
        {
            var appRole = AppRoleManager.FindByIdAsync(id).Result;

            AppRoleManager.Delete(appRole);
            return request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}