using BLL;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace APL.Controllers
{
    public class WorkerController : ApiController
    {
        //Get all Workers
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
        //Get Single Workers
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

        //Get Single Workers all Booking
        [HttpGet]
        [Route("api/workers/{id}/bookings")]
        public HttpResponseMessage WorkerBookings(int id)
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
        //Get single workers single booking
        [HttpGet]
        [Route("api/workers/{workerID}/bookings/{bookingId}")]
        public HttpResponseMessage WorkerSingleBooking(int workerID, int bookingId)
        {
            try
            {
                var data = WorkerService.GetWorkerSingleBooking(workerID, bookingId);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found or not associated with the specified worker." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
       // [HttpPut]
       // [Route("api/workers/{workerID}/bookings/{bookingId}/update")]
       //// update a single booking where status is accepted and move to service history
       //public HttpResponseMessage UpdateWorkerBooking(int workerID, int bookingId, BookingDTO booking)
       // {
       //     try
       //     {
       //         var data = WorkerService.UpdateBookingStatus(workerID, bookingId, booking);

       //         if (data == null)
       //         {
       //             return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Booking not found or not associated with the specified worker." });
       //         }

       //         return Request.CreateResponse(HttpStatusCode.OK, data);
       //     }
       //     catch (Exception ex)
       //     {
       //         return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.InnerException.InnerException });
       //     }
       // }

        //Get Workers Service History
        [HttpGet]
        [Route("api/workers/{id}/servicehistory")]
        public HttpResponseMessage WorkerServiceHistory(int id)
        {
            try
            {
                var data = WorkerService.GetWorkerServiceHistory(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



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

    }
}
