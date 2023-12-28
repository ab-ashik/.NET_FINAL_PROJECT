using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Worker")]
        public int WorkerID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(200)]
        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; }

        //Virtual Properties
        public virtual User User { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual Booking Booking { get; set; }

    }
}
