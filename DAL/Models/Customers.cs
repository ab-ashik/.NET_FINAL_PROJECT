using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customers
    {
        [Key]
        public String Uname { get; set; }

        [Required]
        [StringLength(20)]
        public String Name { get; set; }

        [Required]
        [StringLength(20)]
        public String Password { get; set; }



    }
}
