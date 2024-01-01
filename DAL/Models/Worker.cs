using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Worker
    {
        [Key]
        public int WorkerID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public String Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Specialization { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

       // [Required]
      //  public string [] AvailableDays { get; set; }

        [Required]
        public string AvailableStartTime { get; set; }

        [Required]
        public string AvailableEndTime { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<ServiceHistory> ServiceHistories { get; set; }

        public Worker()
        {
            Bookings = new List<Booking>();
            ServiceHistories = new List<ServiceHistory>();

        }

    }
}
