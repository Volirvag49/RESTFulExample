using RESTFulExample.BLL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface ICartService : IDisposable
    {
        Task<IEnumerable<OrderDTO>> FindByIdEmpAsync(int? employeeId);
        Task AddAirAsync(ServiceDTO services);
        Task AddTrainAsync(ServiceDTO services);
        Task AddHotelAsync(ServiceDTO services);
        Task DeleteAsync(int? CardId);
    }
}
