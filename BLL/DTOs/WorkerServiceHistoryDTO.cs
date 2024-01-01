using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class WorkerServiceHistoryDTO : WorkerDTO
    {
        public List<ServiceHistoryDTO> ServiceHistories { get; set; }
        public WorkerServiceHistoryDTO()
        {
            ServiceHistories = new List<ServiceHistoryDTO>();
        }
    }
}
