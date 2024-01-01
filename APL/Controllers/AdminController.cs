using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APL.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin/bookings/all")]
        public HttpResponseMessage Bookings()
        {
            try
            {
                var data = AdminService.GetAllBooking();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}
