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
    public class CartsEmployeesController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartsEmployeesController(ICartService cartService, IMapper mapper)
        {
            this._cartService = cartService;
            this._mapper = mapper;
        }

        // GET api/values/5
        [HttpGet("{employee_Id}")]
        public async Task<IActionResult> Get(int employee_Id)
        {
            var cartsDTO = await _cartService.FindByIdEmpAsync(employee_Id);
            var cartsVM = Mapper.Map<IEnumerable<CartDTO>, IEnumerable<CartVM>>(cartsDTO);

            if (cartsVM == null)
            {
                return NotFound();
            }

            return new ObjectResult(cartsVM);
        }

        // DELETE api/values/5
        [HttpDelete("{cart_id}")]
        public async Task<IActionResult> Delete(int cart_id)
        {

            try
            {
                await _cartService.DeleteAsync(cart_id);
                return Ok(cart_id);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
