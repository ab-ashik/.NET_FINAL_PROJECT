using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.Models
{
    internal class ServiceAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<DiscountCupon> DiscountCupons { get; set; }

        public DbSet<ServiceHistory> ServicesHistories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Configure other relationships...

            //base.OnModelCreating(modelBuilder);
        }

    }
}
