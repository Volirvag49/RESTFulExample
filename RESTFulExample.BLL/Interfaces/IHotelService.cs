using RESTFulExample.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface IHotelService : IDisposable
    {
        Task<IEnumerable<HotelDTO>> GetAllAsync();
        Task<IEnumerable<HotelDTO>> GetAvailableAsync();
        Task CreateAsync(HotelDTO hotelDTO);
        Task UpdateAsync(HotelDTO hotelDTO);
        Task DeleteAsync(string id);
        Task<HotelDTO> GetByIdAsync(string id);
    }
}
