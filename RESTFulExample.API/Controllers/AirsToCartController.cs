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
    public class AirsToCartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public AirsToCartController(ICartService cartService, IMapper mapper)
        {
            this._cartService = cartService;
            this._mapper = mapper;
        }

       
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceVM serviceVM)
        {
            if (serviceVM.EmployeeId == null || serviceVM.serviceIds.Count == 0)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            try
            {
                ServiceDTO serviceDTO = new ServiceDTO()
                {
                    EmployeeId = serviceVM.EmployeeId,
                    serviceIds = serviceVM.serviceIds
                };
                await _cartService.AddAirAsync(serviceDTO);


                return Ok(serviceVM);
            }
            catch (BusinessLogicException ex)
            {
                BadRequest(ex.Message);

            }

            return BadRequest("Error");
        }     
    }
}
