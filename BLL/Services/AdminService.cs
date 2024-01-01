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


        public static DiscountCuponDTO Get(int id)
        {
            var data = DataAccessFactory.DiscountCuponData().Read(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DiscountCupon, DiscountCuponDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<DiscountCuponDTO>(data);
            return ret;
        }

        public static bool Delete(int id)
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





        //discountCouponDTO
        //CRUD, ServiceCouponDTO

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
