using System;

namespace RESTFulExample.BLL.DTO
{
    public class LogDTO
    {
        public DateTime Event_date { get; set; }
        public string Exception { get; set; }
        public string Method_name { get; set; }
    }
}
