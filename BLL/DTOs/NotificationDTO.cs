using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class NotificationDTO
    {
        public int NotificationID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string NotificationType { get; set; }


    }
}
