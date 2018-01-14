using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RESTFulExample.DAL.Entities
{
    public class Log 
    {
        public ObjectId Id { get; set; }
        public DateTime Event_date { get; set; }
        public string Exception { get; set; }
        public string Method_name { get; set; }
    }
}
