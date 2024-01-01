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
    public class UserController : ApiController
    {
        //[HttpGet]
        //[Route("api/users")]
        //public HttpResponseMessage Users()
        //{
        //    try
        //    {
        //        var data = UserService.Get();

        //        return Request.CreateResponse(HttpStatusCode.OK, data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
        //    }
        //}
        [HttpGet]
        [Route("api/users/{id}")]
        //dfkghdlfhglhdf
        public HttpResponseMessage Users(int id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/user/services")]
        public HttpResponseMessage Services()
        {
            try
            {
                var data = UserService.GetServices();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/user/services/{id}")]
        public HttpResponseMessage Services(int id)
        {
            try
            {
                var data = UserService.GetService(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create(UserDTO user)
        {
            try
            {
                UserService.Create(user);
                return Request.CreateResponse(HttpStatusCode.OK, "created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }

        [HttpPost]
        [Route("api/user/{id}/reviews/create")]
        public HttpResponseMessage CreateReview(ReviewDTO review)
        {
            try
            {
                UserService.CreateReview(review);
                return Request.CreateResponse(HttpStatusCode.OK, "reviewed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }

        [HttpGet]
        [Route("api/user/{id}/reviews")]
        public HttpResponseMessage Reviews(int id)
        {
            try
            {
                var data = UserService.GetReviews(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }
        //Get single user single booking
        [HttpGet]
        [Route("api/user/{id}/bookings/{bookingId}")]
        public HttpResponseMessage WorkerSingleBooking(int id, int bookingId)
        {
            try
            {
                var data = UserService.GetUserSingleBooking(id, bookingId);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found or not associated with the specified user." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



        ///errrrrrrrrooooooooooooooooooooooooooorrrrrrrrrrr
        //[HttpPost]
        //[Route("api/user/{id}/bookings/create")]
        //public HttpResponseMessage UserReviewCreate(int id, ReviewDTO review)
        //{
        //    try
        //    {
        //        UserService.CreateReview(id, review);
        //        return Request.CreateResponse(HttpStatusCode.OK, "reviewed");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
        //    }

        //}

        [HttpGet]
        [Route("api/user/{id}/bookings")]
        public HttpResponseMessage Bookings(int id)
        {
            try
            {
                var data = UserService.GetBookings(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }



       



    }
}
