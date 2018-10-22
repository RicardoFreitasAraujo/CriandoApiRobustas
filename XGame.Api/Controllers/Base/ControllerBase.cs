using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using XGame.Domain.Interfaces.Services.Base;
using XGame.Infra.Transactions;

namespace XGame.Api.Controllers.Base
{
    public class ControllerBase: ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<HttpResponseMessage> ResponseAsync(object result, IServiceBase serviceBase)
        {
            this._serviceBase = serviceBase;

            if (!_serviceBase.Notifications.Any())
            {
                try
                {
                    this._unitOfWork.Commit();

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (Exception ex)
                {
                    //Aqui devo logar erro
                    return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema = {ex.Message}" );
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = serviceBase.Notifications });
            }
        }

        public async Task<HttpResponseMessage> ResponseExceptionAsync(Exception ex)
        {
            return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new { erros = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            if (_serviceBase != null)
            {
                _serviceBase.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}