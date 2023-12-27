using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(20)]
        public string Sname { get; set; }




    }
}
