using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WorkerService
    {
        //Get All Worker List
        public static List<WorkerDTO> Get()
        {
            var data = DataAccessFactory.WorkerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Worker, WorkerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<WorkerDTO>>(data);
            return mapped;

        }

        //Get Single Worker
        public static WorkerDTO Get(int id)
        {
            var data = DataAccessFactory.WorkerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Worker, WorkerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WorkerDTO>(data);
            return mapped;

        }

        //Get single Worker all incoming Bookings
        public static WorkerBookingDTO GetwithBookings(int id)
        {
            var data = DataAccessFactory.WorkerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Worker, WorkerBookingDTO>();
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WorkerBookingDTO>(data);
            return mapped;
        }

        //Get single workers single booking
        public static BookingDTO GetWorkerSingleBooking(int workerID, int bookingId)
        {
            var bookingData = DataAccessFactory.BookingData().Read(bookingId);

            if (bookingData == null || bookingData.WorkerID != workerID)
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });

            var mapper = new Mapper(cfg);
            var mappedBooking = mapper.Map<BookingDTO>(bookingData);

            return mappedBooking;
        }

        //Update a worker single booking 
        public static bool UpdateWorkerSingleBooking(int workerID, int bookingId, BookingDTO updatedBooking)
        {
            var existingBooking = DataAccessFactory.BookingData().Read(bookingId);
            if (existingBooking == null || existingBooking.WorkerID != workerID)
            {
                return false;
            }
            existingBooking.Status = updatedBooking.Status;
            DataAccessFactory.BookingData().Update(existingBooking);
            return true;
        }

        //public static bool UpdateWorkerSingleBooking(int workerID, int bookingId, BookingDTO updatedBooking)
        //{
        //    var existingBooking = DataAccessFactory.BookingData().Read(bookingId);

        //    if (existingBooking == null || existingBooking.WorkerID != workerID)
        //    {
        //        return false;
        //    }

        //    if (updatedBooking.Status == "Accepted")
        //    {
        //        // If the status is "Accepted", move the booking to Service History and delete it from the Booking table

        //        // Create a ServiceHistoryDTO object from the existing booking
        //        var serviceHistory = new ServiceHistoryDTO
        //        {
        //            WorkerID = existingBooking.WorkerID,
        //            UserID = existingBooking.UserID,
        //            ServiceID = existingBooking.ServiceID,
        //            BookingID = existingBooking.BookingID,
        //            //PaymentID = GenerateRandomId(),
        //            //ReviewID = GenerateRandomId(),
        //            BookingDate = existingBooking.BookingDate,
        //            DueDate = existingBooking.DueDate,
        //            CompletionDate = DateTime.Now,
        //        };

        //        // Insert the service history record
        //        DataAccessFactory.ServiceHistoryData().Create(serviceHistory);

        //        // Delete the booking from the Booking table
        //        DataAccessFactory.BookingData().Delete(existingBooking.BookingID);
        //    }
        //    else
        //    {
        //        // If the status is not "Accepted", update the existing booking's status
        //        existingBooking.Status = updatedBooking.Status;
        //        DataAccessFactory.BookingData().Update(existingBooking);
        //    }

        //    return true;
        //}


        //Worker Service History
        public static WorkerServiceHistoryDTO GetWorkerServiceHistory(int id)
        {
            var data = DataAccessFactory.WorkerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Worker, WorkerServiceHistoryDTO>();
                c.CreateMap<ServiceHistory, ServiceHistoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WorkerServiceHistoryDTO>(data);
            return mapped;
        }

        //Create Worker
        public static void Create(WorkerDTO worker)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<WorkerDTO, Worker>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Worker>(worker);
            DataAccessFactory.WorkerData().Create(mapped);
        }

    }
}
