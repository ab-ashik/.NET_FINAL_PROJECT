using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }


        [Required]
        [StringLength(50)]
        public string ServiceTitle { get; set; }

        [Required]
        [StringLength(200)]
        public string ServiceDescription { get; set; }

        [Required]
        public int MinDuration { get; set; }

        [Required]
        public int MaxDuration { get; set; }

        [Required]
        public string PriceRange { get; set; }


    }
}
