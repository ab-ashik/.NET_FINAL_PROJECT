using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        [ForeignKey("Worker")]
        public int WorkerID { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        // public DateTime CompletionDate { get; set; }

        [Required]
        public string Status { get; set; }

        //Virtual Properties
        public virtual User User { get; set; }

        public virtual Service Service { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public Booking()
        {
            Payments = new List<Payment>();
        }


    }
}
