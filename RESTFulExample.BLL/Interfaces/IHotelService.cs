using RESTFulExample.BLL.DTO;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface IHotelService : IDisposable
    {
        Task<IEnumerable> GetAllAsync();
        Task CreateAsync(HotelDTO hotelDTO);
        Task UpdateAsync(HotelDTO hotelDTO);
        Task DeleteAsync(int? id);
        Task<HotelDTO> GetByIdAsync(int? id);
    }
}
