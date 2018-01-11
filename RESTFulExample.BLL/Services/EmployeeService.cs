using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;
using System;
using System.Collections;
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

        public async Task<IEnumerable> GetAllAsync()
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

            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);

            await unitOfWork.Employees.CreateAsync(employee);           
        }     

        public async Task UpdateAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                throw new BusinessLogicException("Требуется клиент", "");
            }

            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);

            await unitOfWork.Employees.UpdateAsync(employee);
        }
      
        public async Task DeleteAsync(int? id)
        {

            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            var employee = await unitOfWork.Employees.GetByIdAsynс(id);

            if (employee == null)
            {
                throw new BusinessLogicException("Клиент не найден", "");
            }

            await unitOfWork.Employees.DeleteAsync(employee);
        }

        public async Task<EmployeeDTO> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            var employee = await Mapper.Map<Task<Employee>, Task<EmployeeDTO>>(unitOfWork.Employees.GetByIdAsynс(id));
            return employee;
        }   

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
