using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.App_Start;
using Work.Model.Models;
using Work.Service;

namespace WebAPI.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected HttpResponseMessage createHttpResponseMessage(HttpRequestMessage requestMessage, Func<HttpResponseMessage> func)
        {
            HttpResponseMessage response = null;
            try
            {
                response = func.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception e)
            {
                LogError(e);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            return response;
        }

        private void LogError(Exception e)
        {
            try
            {
                Error error = new Error();
                error.CreatedDate = DateTime.Now;
                error.error_message = e.Message;
                error.stack_trace = e.StackTrace;
                _errorService.Create(error);
                _errorService.SaveChanges();
            }
            catch
            {
            }
        }
    }
}