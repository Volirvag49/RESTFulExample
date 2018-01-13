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
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            this._cartService = cartService;
            this._mapper = mapper;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cartsDTO = await _cartService.FindByIdAsync(id);
            var cartsVM = Mapper.Map<IEnumerable<CartDTO>, IEnumerable<CartVM>>(cartsDTO);

            if (cartsVM == null)
            {
                return NotFound();
            }

            return new ObjectResult(cartsVM);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] int first, int sec, [FromBody] params int[] some)
        {
            //if (employeeId == null || airVMs == null)
            //{
            //    ModelState.AddModelError("", "Не указаны данные");
            //    return BadRequest(ModelState);
            //}
            var result = new { first, sec,
                some};
            return Ok(some);
        }
    }
}
