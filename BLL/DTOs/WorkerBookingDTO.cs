using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class WorkerBookingDTO : WorkerDTO
    {
        public List<BookingDTO> Bookings { get; set; }
        public WorkerBookingDTO()
        {
            Bookings = new List<BookingDTO>();
        }
    }
}
