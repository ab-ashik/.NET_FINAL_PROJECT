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
        //sfsgs
        //oiugififi
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
