using RESTFulExample.BLL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task CreateAsync(EmployeeDTO employeeDTO);
        Task UpdateAsync(EmployeeDTO employeeDTO);
        Task DeleteAsync(int? id);
        Task<EmployeeDTO> GetByIdAsync(int? id);
    }
}
