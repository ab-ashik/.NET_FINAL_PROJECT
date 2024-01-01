using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        public int Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public DateTime TransactionDate { get; set; }

        public string PaymentStatus { get; set; }


        //Virtual Properties
        public virtual Booking Booking { get; set; }
        public virtual User User { get; set; }
    }
}
