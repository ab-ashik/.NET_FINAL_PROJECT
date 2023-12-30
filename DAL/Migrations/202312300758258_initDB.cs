namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        WorkerID = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Services", t => t.ServiceID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Workers", t => t.WorkerID)
                .Index(t => t.UserID)
                .Index(t => t.ServiceID)
                .Index(t => t.WorkerID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ServiceTitle = c.String(nullable: false, maxLength: 50),
                        ServiceDescription = c.String(nullable: false, maxLength: 200),
                        MinDuration = c.Int(nullable: false),
                        MaxDuration = c.Int(nullable: false),
                        PriceRange = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Specialization = c.String(nullable: false, maxLength: 20),
                        IsAvailable = c.Boolean(nullable: false),
                        AvailableStartTime = c.String(nullable: false),
                        AvailableEndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WorkerID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.DiscountCupons",
                c => new
                    {
                        CuponID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        DiscountPercentage = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CuponID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 60),
                        NotificationType = c.String(),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        BookingID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        PaymentStatus = c.String(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Bookings", t => t.BookingID)
                .Index(t => t.BookingID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        WorkerID = c.Int(nullable: false),
                        BookingID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 200),
                        ReviewDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Bookings", t => t.BookingID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Workers", t => t.WorkerID)
                .Index(t => t.UserID)
                .Index(t => t.WorkerID)
                .Index(t => t.BookingID);
            
            CreateTable(
                "dbo.ServiceHistories",
                c => new
                    {
                        HistoryID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        WorkerID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        BookingID = c.Int(nullable: false),
                        PaymentID = c.Int(nullable: false),
                        ReviewID = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        CompletionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryID)
                .ForeignKey("dbo.Bookings", t => t.BookingID)
                .ForeignKey("dbo.Payments", t => t.PaymentID)
                .ForeignKey("dbo.Reviews", t => t.ReviewID)
                .ForeignKey("dbo.Services", t => t.ServiceID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Workers", t => t.WorkerID)
                .Index(t => t.UserID)
                .Index(t => t.WorkerID)
                .Index(t => t.ServiceID)
                .Index(t => t.BookingID)
                .Index(t => t.PaymentID)
                .Index(t => t.ReviewID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceHistories", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.ServiceHistories", "UserID", "dbo.Users");
            DropForeignKey("dbo.ServiceHistories", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.ServiceHistories", "ReviewID", "dbo.Reviews");
            DropForeignKey("dbo.ServiceHistories", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.ServiceHistories", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Reviews", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.Reviews", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reviews", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Payments", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Notifications", "UserID", "dbo.Users");
            DropForeignKey("dbo.Bookings", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.Workers", "UserID", "dbo.Users");
            DropForeignKey("dbo.Bookings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Bookings", "ServiceID", "dbo.Services");
            DropIndex("dbo.ServiceHistories", new[] { "ReviewID" });
            DropIndex("dbo.ServiceHistories", new[] { "PaymentID" });
            DropIndex("dbo.ServiceHistories", new[] { "BookingID" });
            DropIndex("dbo.ServiceHistories", new[] { "ServiceID" });
            DropIndex("dbo.ServiceHistories", new[] { "WorkerID" });
            DropIndex("dbo.ServiceHistories", new[] { "UserID" });
            DropIndex("dbo.Reviews", new[] { "BookingID" });
            DropIndex("dbo.Reviews", new[] { "WorkerID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.Payments", new[] { "BookingID" });
            DropIndex("dbo.Notifications", new[] { "UserID" });
            DropIndex("dbo.Workers", new[] { "UserID" });
            DropIndex("dbo.Bookings", new[] { "WorkerID" });
            DropIndex("dbo.Bookings", new[] { "ServiceID" });
            DropIndex("dbo.Bookings", new[] { "UserID" });
            DropTable("dbo.ServiceHistories");
            DropTable("dbo.Reviews");
            DropTable("dbo.Payments");
            DropTable("dbo.Notifications");
            DropTable("dbo.DiscountCupons");
            DropTable("dbo.Workers");
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.Bookings");
        }
    }
}
