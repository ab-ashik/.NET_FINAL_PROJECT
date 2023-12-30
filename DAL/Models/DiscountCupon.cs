using System;
using System.ComponentModel.DataAnnotations;

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
