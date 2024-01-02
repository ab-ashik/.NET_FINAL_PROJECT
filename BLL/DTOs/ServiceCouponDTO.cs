using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ServiceCouponDTO : ServiceDTO
    {
        public List<DiscountCuponDTO> DiscountCupons { get; set; }
        public ServiceCouponDTO()
        {
            DiscountCupons = new List<DiscountCuponDTO>();
        }
    }
}
