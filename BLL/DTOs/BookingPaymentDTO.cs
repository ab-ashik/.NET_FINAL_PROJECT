using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookingPaymentDTO : BookingDTO
    {
        public List<PaymentDTO> Payments { get; set; }
        public BookingPaymentDTO()
        {
            Payments = new List<PaymentDTO>();
        }
    }
}
