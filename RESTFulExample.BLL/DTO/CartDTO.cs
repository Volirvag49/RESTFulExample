using RESTFulExample.DAL.Entities;

namespace RESTFulExample.BLL.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }


        public string AirId { get; set; }


        public string TrainId { get; set; }


        public string HotelId { get; set; }

    }
}
