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
using RESTFulExample.API.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    [ExceptionLoggerFilter]
    public class TrainsAvailableController : Controller
    {
        private readonly ITrainService _trainService;
        private readonly IMapper _mapper;

        public TrainsAvailableController(ITrainService trainService, IMapper mapper)
        {
            this._trainService = trainService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var trainsDTO = await _trainService.GetAvailableAsync();
            var trainsVM = Mapper.Map<IEnumerable<TrainDTO>, IEnumerable<TrainVM>>(trainsDTO);
            return trainsVM;
        }
    }
}
