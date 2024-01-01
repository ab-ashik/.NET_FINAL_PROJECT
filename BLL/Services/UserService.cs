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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;

        }   

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;

        }

        public static List<ServiceDTO> GetServices()
        {
            var data = DataAccessFactory.ServiceData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ServiceDTO>>(data);
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

        public static List<WorkerDTO> GetWorkers()
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

        public static void Create(UserDTO user)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<User>(user);
            DataAccessFactory.UserData().Create(mapped);
        }

        public static void CreateReview(ReviewDTO review)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReviewDTO, Review>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Review>(review);
            DataAccessFactory.ReviewData().Create(mapped);
        }
        //public static ReviewDTO CreateReview(int userID, ReviewDTO review)
        //{
        //    var userData = DataAccessFactory.UserData().Read(userID);

        //    if (userData == null)
        //    {
        //        return null;
        //    }

        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<ReviewDTO, Review>();
        //    });

        //    var mapper = new Mapper(cfg);
        //    var mappedReview = mapper.Map<Review>(review);

        //    mappedReview.UserID = userID;

        //    DataAccessFactory.ReviewData().Create(mappedReview);

        //    return review;
        //}

        public static UserReviewDTO GetReviews(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserReviewDTO>();
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserReviewDTO>(data);
            return mapped;

        }

        ///eeeeeeeeeeeerrrrrrrrroooooooooooooooooooooooooooooorrrrrrrrrrrrrrrrrrrrrrrrrrr
        public static void CreateBooking(BookingDTO booking)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingDTO, Booking>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Booking>(booking);
            DataAccessFactory.BookingData().Create(mapped);
        }

        public static UserBookingDTO GetBookings(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserBookingDTO>();
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserBookingDTO>(data);
            return mapped;

        }




        //Get single user single booking
        public static BookingDTO GetUserSingleBooking(int userID, int bookingId)
        {
            var bookingData = DataAccessFactory.BookingData().Read(bookingId);

            if (bookingData == null || bookingData.UserID != userID)
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




    }
}
