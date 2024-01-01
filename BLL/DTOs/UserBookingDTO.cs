using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserBookingDTO : UserDTO
    {
        public List<BookingDTO> Bookings { get; set; }
        public UserBookingDTO()
        {
            Bookings = new List<BookingDTO>();
        }
    }
}
