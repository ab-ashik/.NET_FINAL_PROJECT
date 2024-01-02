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
<<<<<<< HEAD
     
=======
        
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb
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

        public static void CreateService(ServiceDTO service)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceDTO, Service>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Service>(service);
            DataAccessFactory.ServiceData().Create(mapped);
        }

        public static void UpdateService(ServiceDTO service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ServiceDTO, Service>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Service>(service);
            DataAccessFactory.ServiceData().Update(data);
        }

        public static List<UserBookingDTO> GetUserWithBooking()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserBookingDTO>();
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserBookingDTO>>(data);
            return mapped;

        }
        public static void CreateWorker(WorkerDTO worker)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<WorkerDTO, Worker>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Worker>(worker);
            DataAccessFactory.WorkerData().Create(mapped);
        }

<<<<<<< HEAD
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
=======
>>>>>>> 0df696cb3bc801d397c3a6ec355d5dbd241d7dfb


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

        public static List<ServiceHistoryDTO> GetAllServHistories()
        {
            var data = DataAccessFactory.ServiceHistoryData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ServiceHistory, ServiceHistoryDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<ServiceHistoryDTO>>(data);
            return ret;
        }

        //userBookingDTO
        //List

        //UserDTO
        //List, Find

        public static List<UserDTO> GetAllUsers()
        {
            var data = DataAccessFactory.UserData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<UserDTO>>(data);
            return ret;
        }


        public static UserDTO GetUser(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<UserDTO>(data);
            return ret;
        }

        //WorkerDTO
        //Create, Delete, List, Find,  

        public static List<WorkerDTO> GetAllWorkers()
        {
            var data = DataAccessFactory.WorkerData().Read();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Worker, WorkerDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<WorkerDTO>>(data);
            return ret;
        }


        public static WorkerDTO GetWorker(int id)
        {
            var data = DataAccessFactory.WorkerData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Worker, WorkerDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<WorkerDTO>(data);
            return ret;
        }

        public static bool DeleteWorker(int id)
        {
            return DataAccessFactory.WorkerData().Delete(id);
        }

        public static List<UserBookingDTO> GetUserWithBookings()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserBookingDTO>();
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserBookingDTO>>(data);
            return mapped;

        }
    }
}
