using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Worker
    {
        [Key]
        public int WorkerID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string Specialization { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public List<string> AvailableDays { get; set; }

        [Required]
        public string AvailableStartTime { get; set;}

        [Required]
        public string AvailableEndTime { get; set;}

        //Virtual Properties
        public virtual User User { get; set; }
    }
}
