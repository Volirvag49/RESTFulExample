using RESTFulExample.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface IAirService : IDisposable
    {
        Task<IEnumerable<AirDTO>> GetAllAsync();
        Task<IEnumerable<AirDTO>> GetAvailableAsync();
        Task CreateAsync(AirDTO airDTO);
        Task UpdateAsync(AirDTO airDTO);
        Task DeleteAsync(string id);
        Task<AirDTO> GetByIdAsync(string id);

    }
}
