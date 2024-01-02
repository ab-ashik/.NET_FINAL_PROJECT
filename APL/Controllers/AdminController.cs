using BLL.DTOs;
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

        [HttpPost]
        [Route("api/admin/coupon/create")]
        public HttpResponseMessage Create(DiscountCuponDTO data)
        {
            try
            {
                AdminService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        [HttpPost]
        [Route("api/admin/coupon/update")]
        public HttpResponseMessage Update(DiscountCuponDTO data)
        {
            try
            {
                AdminService.Update(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPost]
        [Route("api/admin/service/create")]
        public HttpResponseMessage Create(ServiceDTO data)
        {
            try
            {
                AdminService.CreateService(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPost]
        [Route("api/admin/service/update")]
        public HttpResponseMessage Update(ServiceDTO data)
        {
            try
            {
                AdminService.UpdateService(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/userbooking/all")]
        public HttpResponseMessage GetUserWithBooking()
        {
            try
            {
                var data = AdminService.GetUserWithBooking();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
