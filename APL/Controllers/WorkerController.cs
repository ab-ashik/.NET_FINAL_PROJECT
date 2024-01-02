using BLL;
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
    public class WorkerController : ApiController
    {
        //Get Single Worker
        [HttpGet]
        [Route("api/workers/{id}")]
        public HttpResponseMessage Worker(int id)
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


        //Create Workers
        [HttpPost]
        [Route("api/workers/create")]
        public HttpResponseMessage CreateWorker(WorkerDTO worker)
        {
            try
            {
                WorkerService.Create(worker);
                return Request.CreateResponse(HttpStatusCode.OK, "created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        //Update Workers
        [HttpPut]
        [Route("api/workers/{id}/update")]
        public HttpResponseMessage Update(int id, WorkerDTO updateWorker)
        {
            try
            {
                var success = WorkerService.Update(id, updateWorker);

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


        //All Incoming Bookings
        [HttpGet]
        [Route("api/workers/{id}/incomingBookings")]
        public HttpResponseMessage WorkerIncomingBookings(int id)
        {
            try
            {
                var data = WorkerService.GetIncomingBookings(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        
        //Single Incoming Bookings
        [HttpGet]
        [Route("api/workers/{id}/incomingBookings/{bookingID}")]   
        public HttpResponseMessage WorkerIncomingBookings(int id, int bookingID)
        {
            try
            {
                var data = WorkerService.GetIncomingBookings(id).Where(x => x.BookingID == bookingID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //Update Single Incoming Bookings
        [HttpPut]
        [Route("api/workers/{id}/incomingBookings/{bookingID}/update")]
        public HttpResponseMessage UpdateIncomingBookings(int id, int bookingID, BookingDTO updateBooking)
        {
            try
            {
                var success = WorkerService.UpdateIncomingBookings(id, bookingID, updateBooking);

                if (!success)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Booking successfully updated." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException });
            }
        }


        //All Accepted Bookings
        [HttpGet]
        [Route("api/workers/{id}/acceptedBookings")]
        public HttpResponseMessage WorkerAcceptedBookings(int id)
        {
            try
            {
                var data = WorkerService.GetAcceptedBookings(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //Single Accepted Bookings
        [HttpGet]
        [Route("api/workers/{id}/acceptedBookings/{bookingID}")]
        public HttpResponseMessage WorkerAcceptedBookings(int id, int bookingID)
        {
            try
            {
                var data = WorkerService.GetAcceptedBookings(id).Where(x => x.BookingID == bookingID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //show a worker all bookings
        [HttpGet]
        [Route("api/workers/{id}/allBookings")]
        public HttpResponseMessage WorkerAllBookings(int id)
        {
            try
            {
                var data = WorkerService.GetwithBookings(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }

        //for a workerID and bookingID show all payments
        [HttpGet]
        [Route("api/workers/{id}/allBookings/{bookingID}/payments")]
        public HttpResponseMessage WorkerPayments(int bookingID)
        {
            try
            {
                var data = WorkerService.GetwithPayment(bookingID);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //Get All Service History
        [HttpGet]
        [Route("api/workers/{id}/servicehistory")]
        public HttpResponseMessage WorkerServiceHistory(int id)
        {
            try
            {
                var data = WorkerService.GetServiceHistory(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
 
    }
}
