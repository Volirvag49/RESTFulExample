

namespace RESTFulExample.BLL.DTO
{
    public class OrderDTO
    {

        public string Id { get; set; }
        public int? CartId { get; set; }
        public string ServiceId { get; set; }
        public ServiceTipeDTO ServiceTipe { get; set; }

    }
    public enum ServiceTipeDTO : byte
    {
        Empty = 0,
        Air = 1,
        Train = 2,
        Hotel = 3
    }
}
