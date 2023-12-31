﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [StringLength(60)]
        public string Content { get; set; }

        public string NotificationType { get; set; }

        //  public bool IsRead { get; set; }

        //Virtual Properties
        public virtual User User { get; set; }

    }
}
