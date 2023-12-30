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
    public class ReviewDTO
    {
     
        public int ReviewID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int WorkerID { get; set; }

        [Required]
        public int BookingID { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

    }
}
