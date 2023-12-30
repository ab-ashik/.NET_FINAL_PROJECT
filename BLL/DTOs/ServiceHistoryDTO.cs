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
    public class ServiceHistoryDTO
    {
        public int HistoryID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int WorkerID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        [Required]
        public int BookingID { get; set; }

        [Required]
        public int PaymentID { get; set; }

        [Required]
        public int ReviewID { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime CompletionDate { get; set; }

    }
}
