using System;

namespace RESTFulExample.BLL.DTO
{
    public class LogDTO
    {
        public int Id { get; set; }
        public DateTime event_date { get; set; }
        public string exception { get; set; }
        public string method_name { get; set; }
    }
}
