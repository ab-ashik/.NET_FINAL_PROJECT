using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DiscountCupon
    {
        [Key]
        public int CuponID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int DiscountPercentage { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }



    }
}
