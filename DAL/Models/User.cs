using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

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

        public virtual ICollection<Review> Reviews { get; set; }


        public virtual ICollection<Booking> Bookings { get; set; }

        public User()
        {
            Reviews = new List<Review>();
            Bookings = new List<Booking>();
        }
    }
}
