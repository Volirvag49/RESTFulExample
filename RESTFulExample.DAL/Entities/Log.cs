using System;

namespace RESTFulExample.DAL.Entities
{
    public class Log : BaseEntity
    {
        public DateTime event_date { get; set; }
        public string exception { get; set; }
        public string method_name { get; set; }
    }
}
