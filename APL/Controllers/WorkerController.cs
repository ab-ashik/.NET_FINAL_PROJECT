using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.Controllers
{
    public class WorkerController : ApiController
    {
        [HttpGet]
        [Route("api/workers")]
        public HttpResponseMessage Workers()
        {
            try
            {
                var data = WorkerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/workers/{id}")]
        //dfkghdlfhglhdf
        public HttpResponseMessage Workers(int id)
        {
            try
            {
                var data = WorkerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


    }
}
