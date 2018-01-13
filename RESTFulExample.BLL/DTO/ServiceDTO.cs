using System;
using System.Collections.Generic;
using System.Text;

namespace RESTFulExample.BLL.DTO
{
    public class ServiceDTO
    {
        public int? EmployeeId { get; set; }

        public IList<string> serviceIds { get; set; }
    }
}
