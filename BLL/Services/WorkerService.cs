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
using System.Xml.Linq;

namespace BLL.Services
{
    public class WorkerService
    {

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
        //Updata Worker
        public static bool Update(int id, WorkerDTO updatedWorker)
        {
            var existingWorker = DataAccessFactory.WorkerData().Read(id);
            if (existingWorker == null)
            {
                return false;
            }
            existingWorker.UserName = updatedWorker.UserName;
            existingWorker.Email = updatedWorker.Email;
            existingWorker.Password = updatedWorker.Password;
            existingWorker.PhoneNumber = updatedWorker.PhoneNumber;
            existingWorker.Specialization = updatedWorker.Specialization;
            existingWorker.IsAvailable = updatedWorker.IsAvailable;
            existingWorker.AvailableStartTime = updatedWorker.AvailableStartTime;
            existingWorker.AvailableEndTime = updatedWorker.AvailableEndTime;

            DataAccessFactory.WorkerData().Update(existingWorker);
            return true;
        }

        //ssdsds

        //Get All Incoming Bookings
        public static List<BookingDTO> GetIncomingBookings(int id)
        {
            var data = DataAccessFactory.BookingData().Read().Where(x => x.WorkerID == id && x.Status == "Pending");
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookingDTO>>(data);
            return mapped;
        }

        //Single Incoming Bookings
        public static BookingDTO GetIncomingBookings(int id, int bookingID)
        {
            var data = DataAccessFactory.BookingData().Read().Where(x => x.WorkerID == id && x.Status == "Pending" && x.BookingID == bookingID).FirstOrDefault();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BookingDTO>(data);
            return mapped;
        }

        //Update Incoming Bookings
        public static bool UpdateIncomingBookings(int id, int bookingID, BookingDTO updateBooking)
        {
            var existingBooking = DataAccessFactory.BookingData().Read(bookingID);
            if (existingBooking == null)
            {
                return false;
            }
            existingBooking.Status = updateBooking.Status;
            DataAccessFactory.BookingData().Update(existingBooking);
            return true;
        }

        //All Accepted Bookings
        public static List<BookingDTO> GetAcceptedBookings(int id)
        {
            var data = DataAccessFactory.BookingData().Read().Where(x => x.WorkerID == id && x.Status == "Accepted");
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookingDTO>>(data);
            return mapped;
        }
        //Single Accepted Bookings
        public static BookingDTO GetAcceptedBookings(int id, int bookingID)
        {
            var data = DataAccessFactory.BookingData().Read().Where(x => x.WorkerID == id && x.Status == "Accepted" && x.BookingID == bookingID).FirstOrDefault();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BookingDTO>(data);
            return mapped;
        }

        //show a worker all bookings
        public static WorkerBookingDTO GetwithBookings(int id)
        {
            var data = DataAccessFactory.WorkerData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Worker, WorkerBookingDTO>();
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WorkerBookingDTO>(data);
            return mapped;

        }

        public static BookingPaymentDTO GetwithPayment(int bookingID)
        {
            var data = DataAccessFactory.BookingData().Read(bookingID);

            if (data != null && data.Status == "Accepted")
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Booking, BookingPaymentDTO>();
                    c.CreateMap<Payment, PaymentDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<BookingPaymentDTO>(data);
                return mapped;
            }

            return null;
        }





        public static List<ServiceHistoryDTO> GetServiceHistory(int id)
        {
            var data = DataAccessFactory.ServiceHistoryData().Read().Where(x => x.WorkerID == id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceHistory, ServiceHistoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ServiceHistoryDTO>>(data);
            return mapped;
        }


    }
}
