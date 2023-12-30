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
    public class WorkerDTO
    {
        public int WorkerID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public List<string> AvailableDays { get; set; }

        [Required]
        public string AvailableStartTime { get; set; }

        [Required]
        public string AvailableEndTime { get; set; }
    }
}
