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
    public class PaymentDTO
    {
        public int PaymentID { get; set; }

        [Required]
        public int BookingID { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

    }
}
