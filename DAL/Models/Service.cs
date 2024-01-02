using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<DiscountCupon> DiscountCupons { get; set; }

        public Service() {
            DiscountCupons = new List<DiscountCupon>();
        }

        //  [ForeignKey("Worker")]
        //    public int WorkerID { get; set; }

        //Virtual Properties
        //  public virtual Worker Worker { get; set; }




    }
}
