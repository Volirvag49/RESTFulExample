using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTFulExample.API.Models;
using RESTFulExample.API.Util;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    [ExceptionLoggerFilter]
    public class CartsController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartsController(ICartService cartService, IMapper mapper)
        {
            this._cartService = cartService;
            this._mapper = mapper;
        }

        // GET api/values/5
        [HttpGet("{employee_Id}")]
        public async Task<IActionResult> Get(int employee_Id)
        {
            var orderDTO = await _cartService.FindByIdEmpAsync(employee_Id);
            var ordersVM = Mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderVM>>(orderDTO);

            if (ordersVM == null)
            {
                return NotFound();
            }

            return new ObjectResult(ordersVM);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/[controller]/{cart_id:int}/ClearCart")]
        public async Task<IActionResult> Delete(int cart_id)
        {
            try
            {
                await _cartService.DeleteAllAsync(cart_id);
                return Ok(cart_id);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // DELETE api/values/5
        [HttpDelete("{service_Id}")]
        public async Task<IActionResult> Delete(string service_Id)
        {
            try
            {
                await _cartService.DeleteAsync(service_Id);
                return Ok(service_Id);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
