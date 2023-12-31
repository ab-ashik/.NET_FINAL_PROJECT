using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ServiceHistory
    {
        [Key]
        public int HistoryID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Worker")]
        public int WorkerID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        [ForeignKey("Payment")]
        public int PaymentID { get; set; }

        [ForeignKey("Review")]
        public int ReviewID { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }

        //  public DateTime HistoryDate { get; set; }


        //Virtual Properties
        public virtual User User { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual Service Service { get; set; }

        public virtual Review Review { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
