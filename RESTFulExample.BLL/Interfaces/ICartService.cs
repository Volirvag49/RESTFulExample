using RESTFulExample.BLL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface ICartService : IDisposable
    {
        Task<IEnumerable<CartDTO>> FindByIdAsync(int? employeeId);
        Task AddAirAsync(int? employeeId, string airId);
        Task AddTrainAsync(int? employeeId, string trainId);
        Task AddHotelAsync(int? employeeId, string hotelId);
        Task DeleteAsync(int? CardId);
    }
}
