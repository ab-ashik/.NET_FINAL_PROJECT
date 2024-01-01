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

        [HttpGet]
        [Route("api/admin/services/{id}/coupons")]
        public HttpResponseMessage ServiceWithCoupons(int id)
        {
            try
            {
                var data = AdminService.GetServiceWithCoupons(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/admin/coupon/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.GetAllCoupons();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/coupon/{id}")]
        public HttpResponseMessage GetCoupon(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
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
        [HttpGet]
        [Route("api/admin/coupon/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AdminService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        [HttpGet]
        [Route("api/admin/services/{id}")]
        public HttpResponseMessage GetAdminService(int id)
        {
            try
            {
                var data = AdminService.GetService(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}
