using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ServiceDTO
    {
        public int ServiceID { get; set; }

        [Required]
        public string ServiceTitle { get; set; }

        [Required]
        public string ServiceDescription { get; set; }

        [Required]
        public int MinDuration { get; set; }

        [Required]
        public int MaxDuration { get; set; }

        [Required]
        public string PriceRange { get; set; }
    }
}
