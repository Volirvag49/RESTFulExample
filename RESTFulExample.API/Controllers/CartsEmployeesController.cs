using AutoMapper;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cartsDTO = await _cartService.FindByIdEmpAsync(id);
            var cartsVM = Mapper.Map<IEnumerable<CartDTO>, IEnumerable<CartVM>>(cartsDTO);

            if (cartsVM == null)
            {
                return NotFound();
            }

            return new ObjectResult(cartsVM);
        }
    }
}
