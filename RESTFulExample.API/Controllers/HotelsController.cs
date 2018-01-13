using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTFulExample.API.Models;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsController(IHotelService hotelService, IMapper mapper)
        {
            this._hotelService = hotelService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var hotelsDTO = await _hotelService.GetAllAsync();
            var hotelsVM = Mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelVM>>(hotelsDTO);
            return hotelsVM;
        }

        // GET api/values/5
        [HttpGet("{hotel_id}")]
        public async Task<IActionResult> Get(string hotel_id)
        {
            var hotelsDTO = await _hotelService.GetByIdAsync(hotel_id);
            var hotelsVM = Mapper.Map<HotelDTO, HotelVM>(hotelsDTO);

            if (hotelsVM == null)
            {
                return NotFound();
            }

            return new ObjectResult(hotelsVM);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HotelVM hotelVM)
        {
            if (hotelVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var hotelDTO = Mapper.Map<HotelVM, HotelDTO>(hotelVM);
                await _hotelService.CreateAsync(hotelDTO);
                return Ok(hotelVM);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]HotelVM hotelVM)
        {
            if (hotelVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var hotelDTO = Mapper.Map<HotelVM, HotelDTO>(hotelVM);
                await _hotelService.UpdateAsync(hotelDTO);
                return Ok(hotelVM);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);

            }

        }

        // DELETE api/values/5
        [HttpDelete("{hotel_id}")]
        public async Task<IActionResult> Delete(string hotel_id)
        {
            var hotelDTO = await _hotelService.GetByIdAsync(hotel_id);
            if (hotelDTO == null)
            {
                return NotFound();
            }

            try
            {
                var hotelVM = Mapper.Map<HotelDTO, HotelVM>(hotelDTO);
                await _hotelService.DeleteAsync(hotel_id);
                return Ok(hotelVM);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
