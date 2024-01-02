using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        [HttpPost]
        [Route("api/users/create")]
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

        [HttpPut]
        [Route("api/users/{id}/update")]
        public HttpResponseMessage Update(int id, UserDTO updatedUser)
        {
            try
            {
                var success = UserService.Update(id, updatedUser);

                if (!success)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User successfully updated." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException });
            }
        }



        [HttpGet]
        [Route("api/users/{id}/services")]
        public HttpResponseMessage Services(int id)
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
        [Route("api/users/{id}/services/{serviceID}")]
        public HttpResponseMessage Services(int id, int serviceID)
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

        [HttpGet]
        [Route("api/users/{id}/services/{serviceID}/workers")]
        public HttpResponseMessage Workers(int id, int serviceID)
        {
            try
            {
                var data = UserService.GetWorkersByService(serviceID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.Message });
            }

        }

        [HttpGet]
        [Route("api/users/{id}/services/{serviceID}/workers/{workerID}")]
        //get specific worker
        public HttpResponseMessage Worker(int id, int serviceID, int workerID)
        {
            try
            {
                var data = UserService.GetWorker(workerID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.Message });
            }

        }

        [HttpPost]
        [Route("api/users/{id}/services/{serviceID}/workers/{workerID}/createBooking")]
        public HttpResponseMessage CreateBooking(int id, int serviceID, int workerID, BookingDTO booking)
        {
            try
            {
                UserService.CreateBooking(id, serviceID, workerID, booking);
                return Request.CreateResponse(HttpStatusCode.OK, "created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException });
            }

        } 


        [HttpGet]
        [Route("api/users/{id}/bookings")]
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


        //[HttpPost]
        //[Route("api/users/{id}/bookings/create")]
        //public HttpResponseMessage CreateBooking(int id, BookingDTO booking)
        //{
        //    try
        //    {
        //        UserService.CreateBooking(id, booking);
        //        return Request.CreateResponse(HttpStatusCode.OK, "created");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException });
        //    }

        //}


        [HttpGet]
        [Route("api/users/{id}/bookings/{bookingId}")]
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

        [HttpPut]
        [Route("api/users/{id}/bookings/{bookingId}/update")]
        public HttpResponseMessage UpdateUserSingleBooking(int id, int bookingId, BookingDTO updatedBooking)
        {
            try
            {
                var success = UserService.UpdateUserBooking(id, bookingId, updatedBooking);

                if (!success)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found or not associated with the specified user." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Booking successfully updated." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException });
            }
        }

        [HttpPut]
        [Route("api/users/{id}/bookings/{bookingId}/cancel")]
        public HttpResponseMessage DeleteUserSingleBooking(int id, int bookingId)
        {
            try
            {
                var success = UserService.CancelUserBooking(id, bookingId);

                if (!success)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found or not associated with the specified user." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Booking successfully cancelled." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }
        }

        //check accepted bookings from a user
        [HttpGet]
        [Route("api/users/{id}/bookings/accepted")]
        public HttpResponseMessage AcceptedBookings(int id)
        {
            try
            {
                var data = UserService.GetAcceptedBookings(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }

        }

        //get single accepted bookings from a user
        [HttpGet]
        [Route("api/users/{id}/bookings/accepted/{bookingId}")]
        public HttpResponseMessage AcceptedBooking(int id, int bookingId)
        {
            try
            {
                var data = UserService.GetSingleAcceptedBooking(id, bookingId);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found or not associated with the specified user." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }
        }

        ////pay for accepted booking from a user and change status to PAID and add payment details
        //
        [HttpPost]
        [Route("api/users/{id}/bookings/accepted/{bookingId}/pay")]
        public HttpResponseMessage PayAcceptedBooking(int id, int bookingId, PaymentDTO payment)
        {
            try
            {
                UserService.PayAcceptedBooking(id, bookingId, payment);
                return Request.CreateResponse(HttpStatusCode.OK, "Payment Done Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }
        }

        //show completed bookings from a user
        [HttpGet]
        [Route("api/users/{id}/bookings/completed")]
        public HttpResponseMessage CompletedBookings(int id)
        {
            try
            {
                var data = UserService.GetCompletedBookings(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }

        }

        //get single completed bookings from a user
        [HttpGet]
        [Route("api/users/{id}/bookings/completed/{bookingId}")]
        public HttpResponseMessage CompletedBooking(int id, int bookingId)
        {
            try
            {
                var data = UserService.GetSingleCompletedBooking(id, bookingId);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found or not associated with the specified user." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }
        }

        //make review for a completed booking from a user
        [HttpPost]
        [Route("api/users/{id}/bookings/completed/{bookingId}/review")]
        public HttpResponseMessage ReviewCompletedBooking(int id, int bookingId, ReviewDTO review)
        {
            try
            {
                UserService.ReviewCompletedBooking(id, bookingId, review);
                return Request.CreateResponse(HttpStatusCode.OK, "reviewed");
                }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }
        }

        //show reviews for a user
        [HttpGet]
        [Route("api/users/{id}/reviews")]
        public HttpResponseMessage Reviews(int id)
        {
            try
            {
                var data = UserService.GetReviews(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException.Message });
            }

        }

        [HttpGet]
        [Route("api/users/{id}/reviews/{reviewID}")]
        public HttpResponseMessage UserSingleReview(int id, int reviewID)
        {
            try
            {
                var data = UserService.GetUserSingleReview(id, reviewID);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Review not found or not associated with the specified user." });
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


        //[HttpPost]
        //[Route("api/users/{id}/reviews/create")]
        //public HttpResponseMessage CreateReview(ReviewDTO review)
        //{
        //    try
        //    {
        //        UserService.CreateReview(review);
        //        return Request.CreateResponse(HttpStatusCode.OK, "reviewed");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
        //    }

        //}

        //[HttpGet]
        //[Route("api/users/{id}/reviews")]
        //public HttpResponseMessage Reviews(int id)
        //{
        //    try
        //    {
        //        var data = UserService.GetReviews(id);
        //        return Request.CreateResponse(HttpStatusCode.OK, data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
        //    }

        //}



        [HttpPut]
        [Route("api/users/{id}/reviews/{reviewID}/update")]
        public HttpResponseMessage UpdateUserSingleReview(int id, int reviewID, ReviewDTO updatedReview)
        {
            try
            {
                var success = UserService.UpdateUserReview(id, reviewID, updatedReview);

                if (!success)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Review not found or not associated with the specified user." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Review successfully updated." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException });
            }
        }

        //show payments for a user
        [HttpGet]
        [Route("api/users/{id}/payments")]
        public HttpResponseMessage UserPayments(int id)
        {
            try
            {
                var data = UserService.GetPayments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }








    }
}
