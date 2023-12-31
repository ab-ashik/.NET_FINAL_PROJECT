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
        [Key]
        public int WorkerID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public String Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20)]
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
