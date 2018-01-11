using RESTFulExample.DAL.Entities;

namespace RESTFulExample.BLL.DTO
{
    public class BasketDTO
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }

        public string AirId { get; set; }
        public AirDTO Air { get; set; }

        public string TrainId { get; set; }
        public TrainDTO Train { get; set; }

        public string HotelId { get; set; }
        public HotelDTO Hotel { get; set; }
    }
}
