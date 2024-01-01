namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.ServiceAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.ServiceAppContext context)
        {
            Random random = new Random(8);
            for (int i = 0; i < 5; i++)
            {
                string userType = (random.Next(2) == 0) ? "Customer" : "Worker";

                context.Users.AddOrUpdate(new Models.User
                {
                    UserID = i + 1,
                    UserName = Guid.NewGuid().ToString().Substring(0, 15),
                    Email = Guid.NewGuid().ToString().Substring(0, 8) + "@gmail.com",
                    Password = Guid.NewGuid().ToString().Substring(0, 8),
                    PhoneNumber = "+88017" + random.Next().ToString(),
                    //UserType = userType
                });
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    Models.User user = context.Users.FirstOrDefault(u => u.UserID == i + 1);

            //    if (user != null)
            //    {
            //        context.Workers.AddOrUpdate(new Models.Worker
            //        {
            //            WorkerID = i + 1,
            //            UserID = user.UserID,
            //            Specialization = "Electrician",
            //            IsAvailable = true,
            //            AvailableDays = new List<string>(new string[] { "Sunday", "Tuesday", "Friday" }),
            //            AvailableStartTime = "10 AM",
            //            AvailableEndTime = "4 PM",
            //        });
            //    }
            //    else
            //    {

            //        // Handle the case where the corresponding user is not found
            //        // This can be logging, throwing an exception, or other appropriate actions.
            //    }
            //}


            for (int i = 0; i < 5; i++)
            {
                context.Workers.AddOrUpdate(new Models.Worker
                {
                    WorkerID = i + 1,
                    // UserID = i + 1,
                    UserName = Guid.NewGuid().ToString().Substring(0, 15),
                    Email = Guid.NewGuid().ToString().Substring(0, 8) + "@gmail.com",
                    Password = Guid.NewGuid().ToString().Substring(0, 8),
                    PhoneNumber = "+88017" + random.Next().ToString(),
                    Specialization = "Electrician",
                    IsAvailable = true,
                    AvailableDays = new List<string>(new string[] { "Sunday", "Tuesday", "Friday" }),
                    AvailableStartTime = "10 AM",
                    AvailableEndTime = "4 PM",
                });

            }


            for (int i = 0; i < 2; i++)
            {
                context.Services.AddOrUpdate(new Models.Service
                {
                    ServiceID = i + 1,
                    ServiceTitle = "Electrician",
                    ServiceDescription = "This is a electric service, provided by electrician",
                    MinDuration = 30,
                    MaxDuration = 120,
                    PriceRange = "200-2000"

                });
            }

            for (int i = 0; i < 2; i++)
            {
                context.Bookings.AddOrUpdate(new Models.Booking
                {
                    BookingID = i + 1,
                    UserID = i + 1,
                    ServiceID = i + 1,
                    WorkerID = i + 1,
                    BookingDate = new DateTime(2023, 12, 25),
                    DueDate = new DateTime(2023, 12, 26),
                    Status = "Pending"
                });
            }

            for (int i = 0; i < 2; i++)
            {
                context.Payments.AddOrUpdate(new Models.Payment
                {
                    PaymentID = i + 1,
                    BookingID = i + 1,
                    Amount = 500,
                    PaymentMethod = "Online",
                    TransactionDate = new DateTime(2023, 12, 26),
                    PaymentStatus = "Complete"

                });
            }

            for (int i = 0; i < 2; i++)
            {
                context.Reviews.AddOrUpdate(new Models.Review
                {
                    ReviewID = i + 1,
                    UserID = i + 1,
                    WorkerID = i + 1,
                    BookingID = i + 1,

                    Rating = 4,
                    Comment = "He worked well",
                    ReviewDate = new DateTime(2023, 12, 26)

                });
            }

            for (int i = 0; i < 2; i++)
            {
                context.Notifications.AddOrUpdate(new Models.Notification
                {
                    NotificationID = i + 1,
                    UserID = i + 1,
                    Content = "Your payment for Order#111 has completed",
                    NotificationType = "Payment",

                });
            }

            for (int i = 0; i < 2; i++)
            {
                context.DiscountCupons.AddOrUpdate(new Models.DiscountCupon
                {
                    CuponID = i + 1,
                    Code = Guid.NewGuid().ToString().Substring(1, 6).ToUpper(),
                    DiscountPercentage = 20,
                    Description = "This is a 20% discount cupon",
                    ExpiryDate = new DateTime(2023, 12, 30),
                    IsActive = true,

                });
            }

            //DateTime date = new DateTime();
            for (int i = 0; i < 2; i++)
            {
                context.ServicesHistories.AddOrUpdate(new Models.ServiceHistory
                {
                    HistoryID = i + 1,
                    UserID = i + 1,
                    WorkerID = i + 1,
                    ServiceID = i + 1,
                    BookingID = i + 1,
                    PaymentID = i + 1,
                    ReviewID = i + 1,
                    BookingDate = new DateTime(2023, 12, 24),
                    DueDate = new DateTime(2023, 12, 28),
                    CompletionDate = new DateTime(2023, 12, 27),


                });
            }
        }
    }
}
