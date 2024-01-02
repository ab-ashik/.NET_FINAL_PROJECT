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

<<<<<<< HEAD
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
                var data = AdminService.GetCoupon(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

=======
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
        [HttpPost]
        [Route("api/admin/coupon/create")]
        public HttpResponseMessage Create(DiscountCuponDTO data)
        {
            try
            {
<<<<<<< HEAD
                AdminService.CreateCoupon(data);
=======
                AdminService.Create(data);
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
<<<<<<< HEAD

=======
        
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
        [HttpPost]
        [Route("api/admin/coupon/update")]
        public HttpResponseMessage Update(DiscountCuponDTO data)
        {
            try
            {
<<<<<<< HEAD
                AdminService.UpdateCoupon(data);
=======
                AdminService.Update(data);
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
<<<<<<< HEAD
        [HttpGet]
        [Route("api/admin/coupon/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AdminService.DeleteCoupon(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/admin/notification/all")]
        public HttpResponseMessage GetNotif()
        {
            try
            {
                var data = AdminService.GetAllNotifications();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/notification/{id}")]
        public HttpResponseMessage GetNotif(int id)
        {
            try
            {
                var data = AdminService.GetNotification(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("api/admin/coupon/notification/{id}")]
        public HttpResponseMessage DeleteNotif(int id)
        {
            try
            {
                var data = AdminService.DeleteNotification(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
=======


        [HttpPost]
        [Route("api/admin/service/create")]
        public HttpResponseMessage Create(ServiceDTO data)
        {
            try
            {
                AdminService.CreateService(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
<<<<<<< HEAD


        [HttpGet]
        [Route("api/admin/payment/all")]
        public HttpResponseMessage GetPaymentList()
        {
            try
            {
                var data = AdminService.GetAllPayments();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/review/all")]
        public HttpResponseMessage GetReviewList()
        {
            try
            {
                var data = AdminService.GetAllReviews();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/review/{id}")]
        public HttpResponseMessage GetRev(int id)
        {
            try
            {
                var data = AdminService.GetReview(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/service/all")]
        public HttpResponseMessage GetServiceList()
        {
            try
            {
                var data = AdminService.GetAllServices();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/service/{id}")]
        public HttpResponseMessage GetServ(int id)
        {
            try
            {
                var data = AdminService.GetService(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("api/admin/service/delete/{id}")]
        public HttpResponseMessage DeleteServ(int id)
        {
            try
            {
                var data = AdminService.DeleteService(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/service/history/all")]
        public HttpResponseMessage GetAllServHist()
        {
            try
            {
                var data = AdminService.GetAllServHistories();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/user/all")]
        public HttpResponseMessage GetAllUser()
        {
            try
            {
                var data = AdminService.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/user/{id}")]
        public HttpResponseMessage GetOneUser(int id)
        {
            try
            {
                var data = AdminService.GetUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/worker/all")]
        public HttpResponseMessage GetAllWorker()
        {
            try
            {
                var data = AdminService.GetAllWorkers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/admin/worker/{id}")]
        public HttpResponseMessage GetOneWorker(int id)
        {
            try
            {
                var data = AdminService.GetWorker(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("api/admin/worker/delete/{id}")]
        public HttpResponseMessage DeleteWrkr(int id)
        {
            try
            {
                var data = AdminService.DeleteWorker(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
=======
        [HttpPost]
        [Route("api/admin/service/update")]
        public HttpResponseMessage Update(ServiceDTO data)
        {
            try
            {
                AdminService.UpdateService(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
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
<<<<<<< HEAD
                var data = AdminService.GetUserWithBookings();
=======
                var data = AdminService.GetUserWithBooking();
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
<<<<<<< HEAD

=======
        [HttpPost]
        [Route("api/admin/worker/create")]
        public HttpResponseMessage Create(WorkerDTO data)
        {
            try
            {
                AdminService.CreateWorker(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
    }
}
