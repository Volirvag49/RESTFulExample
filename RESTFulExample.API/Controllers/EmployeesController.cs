﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTFulExample.API.Models;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            this._employeeService = employeeService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var employeesDTO = await _employeeService.GetAllAsync();
            var employeesVM = Mapper.Map<IEnumerable<EmployeeDTO>, IEnumerable<EmployeeVM>>(employeesDTO);
            return employeesVM;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employeeDTO = await _employeeService.GetByIdAsync(id);
            var employeesVM = Mapper.Map<EmployeeDTO, EmployeeVM>(employeeDTO);
            return new ObjectResult (employeesVM);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeVM employeeVM)
        {
            if (employeeVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var employeesDTO = Mapper.Map<EmployeeVM, EmployeeDTO>(employeeVM);
                await _employeeService.CreateAsync(employeesDTO);
                return Ok(employeeVM);
            }
            catch (BusinessLogicException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);

            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]EmployeeVM employeeVM)
        {
            if (employeeVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var employeesDTO = Mapper.Map<EmployeeVM, EmployeeDTO>(employeeVM);
                await _employeeService.UpdateAsync(employeesDTO);
                return Ok(employeeVM);
            }
            catch (BusinessLogicException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);

            }
            return BadRequest();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employeeDTO = await _employeeService.GetByIdAsync(id);
            if (employeeDTO == null)
            {
                return NotFound();
            }

            try
            {
                var employeesVM = Mapper.Map<EmployeeDTO, EmployeeVM>(employeeDTO);
                await _employeeService.DeleteAsync(id);
                return Ok(employeesVM);
            }
            catch (BusinessLogicException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);

            }
            return BadRequest();
        }
    }
}