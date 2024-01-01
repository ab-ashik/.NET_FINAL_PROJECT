using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        //bookingDTO
        //admin can see user bookings with worker information and service.
        
        public static List<BookingDTO> GetAllBooking()
        {
            var data = DataAccessFactory.BookingData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookingDTO>>(data);
            return mapped;

        }
        public static void Create(DiscountCuponDTO discountCupon)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DiscountCuponDTO, DiscountCupon>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiscountCupon>(discountCupon);
            DataAccessFactory.DiscountCuponData().Create(mapped);
        }

        public static void Update(DiscountCuponDTO discountCupon)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DiscountCuponDTO, DiscountCupon>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DiscountCupon>(discountCupon);
            DataAccessFactory.DiscountCuponData().Update(data);
        }

        public static void CreateNotification(NotificationDTO notification)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<NotificationDTO, Notification>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Notification>(notification);
            DataAccessFactory.NotificationData().Create(mapped);
        }

        public static void UpdateNotification(NotificationDTO notification)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NotificationDTO, Notification>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Notification>(notification);
            DataAccessFactory.NotificationData().Update(data);
        }

        //notificationDTO
        //CRUD

        //paymentDTo
        //paymentList (BookingDTO, PaymentDTO)

        //ReviewDTO
        //ReviewList, Find

        //ServiceDTO
        //CRUD, Service-WorkerDTO (List)

        //ServiceHistory
        //List

        //userBookingDTO
        //List

        //UserDTO
        //List, Find

        //WorkerDTO
        //Create, Delete, List, Find,  
    }
}
