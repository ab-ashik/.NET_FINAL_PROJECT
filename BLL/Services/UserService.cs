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
    public class UserService
    {
        //public static List<UserDTO> Get()
        //{
        //    var data = DataAccessFactory.UserData().Read();
        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<User, UserDTO>();
        //    });
        //    var mapper = new Mapper(cfg);
        //    var mapped = mapper.Map<List<UserDTO>>(data);
        //    return mapped;

        //}
        //
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
        public static bool Update(int id, UserDTO updatedUser)
        {
            var existingUser = DataAccessFactory.UserData().Read(id);
            if (existingUser == null)
            {
                return false;
            }
            existingUser.UserName = updatedUser.UserName;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            DataAccessFactory.UserData().Update(existingUser);
            return true;
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

        public static List<WorkerDTO> GetWorkersByService(int serviceID)
        {
            var data = DataAccessFactory.ServiceData().Read(serviceID);
            var data2 = DataAccessFactory.WorkerData().Read().Where(w => w.Specialization == data.ServiceTitle);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Worker, WorkerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<WorkerDTO>>(data2);
            return mapped;

        }


        public static WorkerDTO GetWorker(int workerID)
        {
            var data = DataAccessFactory.WorkerData().Read(workerID);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Worker, WorkerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WorkerDTO>(data);
            return mapped;

        }


        public static void CreateBooking(int userID, int serviceID, int workerID, BookingDTO booking)
        {
            var userData = DataAccessFactory.UserData().Read(userID);
            var workerData = DataAccessFactory.WorkerData().Read(workerID);
            var serviceData = DataAccessFactory.ServiceData().Read(serviceID);

            if (userData == null || workerData == null || serviceData == null)
            {
                return;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingDTO, Booking>();
            });

            var mapper = new Mapper(cfg);
            var mappedBooking = mapper.Map<Booking>(booking);

            mappedBooking.UserID = userID;
            mappedBooking.WorkerID = workerID;
            mappedBooking.ServiceID = serviceID;
            mappedBooking.BookingDate = DateTime.Now;
            mappedBooking.Status = "Booking Pending and Payment Pending";

            DataAccessFactory.BookingData().Create(mappedBooking);

            return;
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




        public static bool UpdateUserBooking(int userID, int bookingId, BookingDTO updatedBooking)
        {
            var existingBooking = DataAccessFactory.BookingData().Read(bookingId);

            if (existingBooking == null || existingBooking.UserID != userID)
            {
                return false;
            }
            existingBooking.DueDate = updatedBooking.DueDate;
            //existingBooking.Status = updatedBooking.Status;
            DataAccessFactory.BookingData().Update(existingBooking);
            return true;
        }


        public static bool CancelUserBooking(int userID, int bookingId)
        {
            var bookingData = DataAccessFactory.BookingData().Read(bookingId);

            if (bookingData == null || bookingData.UserID != userID)
            {
                return false;
            }
            bookingData.Status = "Cancelled";

            DataAccessFactory.BookingData().Update(bookingData);

            return true;
        }

        public static void CreatePayment(int userID, int bookingID, PaymentDTO payment)
        {
            var userData = DataAccessFactory.UserData().Read(userID);
            var bookingData = DataAccessFactory.BookingData().Read(bookingID);

            if (userData == null || bookingData == null)
            {
                return;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDTO, Payment>();
            });

            var mapper = new Mapper(cfg);
            var mappedPayment = mapper.Map<Payment>(payment);

            mappedPayment.UserID = userID;
            mappedPayment.BookingID = bookingID;
            mappedPayment.TransactionDate = DateTime.Now;
            mappedPayment.PaymentStatus = "Pending";

            DataAccessFactory.PaymentData().Create(mappedPayment);

            return;
        }





        //public static List<WorkerDTO> GetWorkers()
        //{
        //    var data = DataAccessFactory.WorkerData().Read();
        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<Worker, WorkerDTO>();
        //    });
        //    var mapper = new Mapper(cfg);
        //    var mapped = mapper.Map<List<WorkerDTO>>(data);
        //    return mapped;

        //}

        public static List<BookingDTO> GetAcceptedBookings(int userID)
        {
            var data = DataAccessFactory.BookingData().Read().Where(b => b.UserID == userID && b.Status == "Accepted");
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookingDTO>>(data);
            return mapped;

        }

        public static BookingDTO GetSingleAcceptedBooking(int userID, int bookingID)
        {
            var bookingData = DataAccessFactory.BookingData().Read(bookingID);

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


        public static void PayAcceptedBooking(int userID, int bookingID, PaymentDTO payment)
        {
            var bookingData = DataAccessFactory.BookingData().Read(bookingID);

            if (bookingData == null || bookingData.UserID != userID)
            {
                return;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDTO, Payment>();
            });

            var mapper = new Mapper(cfg);
            var mappedPayment = mapper.Map<Payment>(payment);

            mappedPayment.UserID = userID;
            mappedPayment.BookingID = bookingID;
            mappedPayment.TransactionDate = DateTime.Now;
            mappedPayment.PaymentStatus = "Paid";

            DataAccessFactory.PaymentData().Create(mappedPayment);

            bookingData.Status = "Complete";

            DataAccessFactory.BookingData().Update(bookingData);

            return;
        }


        public static List<BookingDTO> GetCompletedBookings(int userID)
        {
            var data = DataAccessFactory.BookingData().Read().Where(b => b.UserID == userID && b.Status == "Completed");
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookingDTO>>(data);
            return mapped;

        }

        public static BookingDTO GetSingleCompletedBooking(int userID, int bookingID)
        {
            var bookingData = DataAccessFactory.BookingData().Read(bookingID);

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

        public static void ReviewCompletedBooking(int userID, int bookingID, ReviewDTO review)
        {
            var bookingData = DataAccessFactory.BookingData().Read(bookingID);

            if (bookingData == null || bookingData.UserID != userID)
            {
                return;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReviewDTO, Review>();
            });

            var mapper = new Mapper(cfg);
            var mappedReview = mapper.Map<Review>(review);

            mappedReview.UserID = userID;
            mappedReview.WorkerID = bookingData.WorkerID;
            mappedReview.BookingID = bookingID;
            mappedReview.ReviewDate = DateTime.Now;

            DataAccessFactory.ReviewData().Create(mappedReview);

            return;
        }

        //public static List<ReviewDTO> GetReviewsFromUser(int userID)
        //{
        //    var data = DataAccessFactory.ReviewData().Read().Where(r => r.UserID == userID);
        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<Review, ReviewDTO>();
        //    });
        //    var mapper = new Mapper(cfg);
        //    var mapped = mapper.Map<List<ReviewDTO>>(data);
        //    return mapped;

        //}


        //public static void CreateReview(ReviewDTO review)
        //{
        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<ReviewDTO, Review>();
        //    });
        //    var mapper = new Mapper(cfg);
        //    var mapped = mapper.Map<Review>(review);
        //    DataAccessFactory.ReviewData().Create(mapped);
        //}
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

        //from a user get all workers of specific service





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

        public static bool UpdateUserReview(int userID, int reviewID, ReviewDTO updatedReview)
        {
            var existingReview = DataAccessFactory.ReviewData().Read(reviewID);
            if (existingReview == null || existingReview.UserID != userID)
            {
                return false;
            }
            existingReview.Comment = updatedReview.Comment;
            existingReview.Rating = updatedReview.Rating;
            DataAccessFactory.ReviewData().Update(existingReview);
            return true;
        }

        public static ReviewDTO GetUserSingleReview(int userID, int reviewID)
        {
            var reviewData = DataAccessFactory.ReviewData().Read(reviewID);

            if (reviewData == null || reviewData.UserID != userID)
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });

            var mapper = new Mapper(cfg);
            var mappedReview = mapper.Map<ReviewDTO>(reviewData);

            return mappedReview;
        }


        public static List<PaymentDTO> GetPayments(int userID)
        {
            var data = DataAccessFactory.PaymentData().Read().Where(p => p.UserID == userID);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;

        }


        

















    }
}
