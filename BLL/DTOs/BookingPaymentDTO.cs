using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookingPaymentDTO : BookingDTO
    {
<<<<<<< HEAD
        public List<PaymentDTO> payments { get; set; }
        public BookingPaymentDTO()
        {
            payments = new List<PaymentDTO>();
=======
        public List<PaymentDTO> Payments { get; set; }
        public BookingPaymentDTO()
        {
            Payments = new List<PaymentDTO>();
>>>>>>> fc8be69951d1f3e08bcf522166893edf99eff76d
        }
    }
}
