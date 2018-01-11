using RESTFulExample.BLL.DTO;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface IAirService : IDisposable
    {
        Task<IEnumerable> GetAllAsync();
        Task CreateAsync(AirDTO airDTO);
        Task UpdateAsync(AirDTO airDTO);
        Task DeleteAsync(int? id);
        Task<AirDTO> GetByIdAsync(int? id);

    }
}
