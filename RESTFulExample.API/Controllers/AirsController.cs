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


namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    public class AirsController : Controller
    {
        private readonly IAirService _airService;
        private readonly IMapper _mapper;

        public AirsController(IAirService airService, IMapper mapper)
        {
            this._airService = airService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var airsDTO = await _airService.GetAllAsync();
            var airsVM = Mapper.Map<IEnumerable<AirDTO>, IEnumerable<AirVM>>(airsDTO);
            return airsVM;
        }

        // GET api/values/5
        [HttpGet("{air_id}")]
        public async Task<IActionResult> Get(string air_id)
        {
            var airDTO = await _airService.GetByIdAsync(air_id);
            var airVM = Mapper.Map<AirDTO, AirVM>(airDTO);

            if (airVM == null)
            {
                return NotFound();
            }

            return new ObjectResult(airVM);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AirVM airVM)
        {
            if (airVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var airDTO = Mapper.Map<AirVM, AirDTO>(airVM);
                await _airService.CreateAsync(airDTO);
                return Ok(airVM);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]AirVM airVM)
        {
            if (airVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var airDTO = Mapper.Map<AirVM, AirDTO>(airVM);
                await _airService.UpdateAsync(airDTO);
                return Ok(airVM);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{air_Id}")]
        public async Task<IActionResult> Delete(string air_Id)
        {
            var airDTO = await _airService.GetByIdAsync(air_Id);
            if (airDTO == null)
            {
                return NotFound();
            }

            try
            {
                var airVM = Mapper.Map<AirDTO, AirVM>(airDTO);
                await _airService.DeleteAsync(air_Id);
                return Ok(airVM);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
