using RESTFulExample.BLL.DTO;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface IBasketService : IDisposable
    {
        Task<IEnumerable> FindByEmpIdAsync(int? id);
        Task AddAirAsync(int? employeeId, string airId);
        Task AddTrainAsync(int? employeeId, string trainId);
        Task AddHotelAsync(int? employeeId, string hotelId);
        Task DeleteAsync(int? BasketId);
    }
}
