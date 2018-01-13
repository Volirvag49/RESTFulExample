using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulExample.BLL.Interfaces;
using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.API.Models;
using System.Collections;
using RESTFulExample.BLL.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    public class AirsAvailableController : Controller
    {

        private readonly IAirService _airService;
        private readonly IMapper _mapper;

        public AirsAvailableController(IAirService airService, IMapper mapper)
        {
            this._airService = airService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var airsDTO = await _airService.GetAvailableAsync();
            var airsVM = Mapper.Map<IEnumerable<AirDTO>, IEnumerable<AirVM>>(airsDTO);
            return airsVM;
        }
    }
}
