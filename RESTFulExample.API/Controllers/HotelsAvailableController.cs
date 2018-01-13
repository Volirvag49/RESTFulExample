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
    public class HotelsAvailableController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsAvailableController(IHotelService hotelService, IMapper mapper)
        {
            this._hotelService = hotelService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var hotelsDTO = await _hotelService.GetAvailableAsync();
            var hotelsVM = Mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelVM>>(hotelsDTO);
            return hotelsVM;
        }
    }
}
