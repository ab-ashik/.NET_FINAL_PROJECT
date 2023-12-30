using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, string, User>UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Worker, int, Worker> WorkerData()
        {
            return new WorkerRepo();
        }
        public static IRepo<Booking, int, Booking> BookingData()
        {
            return new BookingRepo();
        }
        public static IRepo<Service, int, Service> ServiceData()
        {
            return new ServiceRepo();
        }
        public static IRepo<ServiceHistory, int, ServiceHistory> ServiceHistoryData()
        {
            return new ServiceHistoryRepo();
        }
        public static IRepo<Review, int, Review> ReviewData()
        {
            return new ReviewRepo();
        }
        public static IRepo<Payment, int, Payment> PaymentData()
        {
            return new PaymentRepo();
        }
        public static IRepo<Notification, int, Notification> NotificationData()
        {
            return new NotificationRepo();
        }
        public static IRepo<DiscountCupon, int, DiscountCupon> DiscountCuponData()
        {
            return new DiscountCuponRepo();
        }
    }
}
