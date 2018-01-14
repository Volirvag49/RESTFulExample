using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork unitOfWork { get; set; }

        public EmployeeService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var employees = await Mapper.Map<Task<IEnumerable<Employee>>, Task<IEnumerable<EmployeeDTO>>>(unitOfWork.Employees.GetAllAsync());
            return employees;
        }
    
        public async Task CreateAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                throw new BusinessLogicException("Требуется клиент", "");
            }

            Employee employee = new Employee() {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName
            };

             unitOfWork.Employees.Create(employee);

            await unitOfWork.CommitAsync();

            Cart cart = new Cart()
            {
                EmployeeId = employee.Id
            };

            unitOfWork.Carts.Create(cart);
            await unitOfWork.CommitAsync();
        }     

        public async Task UpdateAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                throw new BusinessLogicException("Требуется клиент", "");
            }

            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);

            unitOfWork.Employees.Update(employee);
            await unitOfWork.CommitAsync();
        }
      
        public async Task DeleteAsync(int? id)
        {

            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            Employee employee = await unitOfWork.Employees.GetByIdAsynс(id);

            if (employee == null)
            {
                throw new BusinessLogicException("Клиент не найден", "");
            }

            unitOfWork.Employees.Delete(employee);
            await unitOfWork.CommitAsync();
        }

        public async Task<EmployeeDTO> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            EmployeeDTO employeeDTO = await Mapper.Map<Task<Employee>, Task<EmployeeDTO>>(unitOfWork.Employees.GetByIdAsynс(id));
            return employeeDTO;
        }   

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
