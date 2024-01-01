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

        //discountCouponDTO
        //CRUD, ServiceCouponDTO

        public static void CreateCoupon(DiscountCuponDTO discountCupon)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DiscountCuponDTO, DiscountCupon>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiscountCupon>(discountCupon);
            DataAccessFactory.DiscountCuponData().Create(mapped);
        }

        public static void UpdateCoupon(DiscountCuponDTO discountCupon)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DiscountCuponDTO, DiscountCupon>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DiscountCupon>(discountCupon);
            DataAccessFactory.DiscountCuponData().Update(data);
        }

        public static List<DiscountCuponDTO> GetAllCoupons()
        {
            var data = DataAccessFactory.DiscountCuponData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DiscountCupon, DiscountCuponDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<DiscountCuponDTO>>(data);
            return ret;
        }


        public static DiscountCuponDTO GetCoupon(int id)
        {
            var data = DataAccessFactory.DiscountCuponData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DiscountCupon, DiscountCuponDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<DiscountCuponDTO>(data);
            return ret;
        }

        public static bool DeleteCoupon(int id)
        {
            return DataAccessFactory.DiscountCuponData().Delete(id);
        }


        public static ServiceCouponDTO GetServiceWithCoupons(int id)
        {
            var data = DataAccessFactory.ServiceData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceCouponDTO>();
                c.CreateMap<DiscountCupon, DiscountCuponDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceCouponDTO>(data);
            return mapped;

        }


        //notificationDTO
        //CRUD


        public static List<NotificationDTO> GetAllNotifications()
        {
            var data = DataAccessFactory.NotificationData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notification, NotificationDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<NotificationDTO>>(data);
            return ret;
        }


        public static NotificationDTO GetNotification(int id)
        {
            var data = DataAccessFactory.NotificationData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notification, NotificationDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<NotificationDTO>(data);
            return ret;
        }

        public static bool DeleteNotification(int id)
        {
            return DataAccessFactory.DiscountCuponData().Delete(id);
        }

        //paymentDTo
        //paymentList (BookingDTO, PaymentDTO)

        public static List<PaymentDTO> GetAllPayments()
        {
            var data = DataAccessFactory.PaymentData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<PaymentDTO>>(data);
            return ret;
        }

        //ReviewDTO
        //ReviewList, Find

        public static List<ReviewDTO> GetAllReviews()
        {
            var data = DataAccessFactory.ReviewData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<ReviewDTO>>(data);
            return ret;
        }


        public static ReviewDTO GetReview(int id)
        {
            var data = DataAccessFactory.ReviewData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<ReviewDTO>(data);
            return ret;
        }

        //ServiceDTO
        //CRUD, Service-WorkerDTO (List)

        public static List<ServiceDTO> GetAllServices()
        {
            var data = DataAccessFactory.ServiceData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<ServiceDTO>>(data);
            return ret;
        }


        public static ServiceDTO GetService(int id)
        {
            var data = DataAccessFactory.ServiceData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceDTO>(data);
            return mapped;

        }

        public static bool DeleteService(int id)
        {
            return DataAccessFactory.ServiceData().Delete(id);
        }

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
