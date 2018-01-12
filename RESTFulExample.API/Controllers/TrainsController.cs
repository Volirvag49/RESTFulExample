﻿using AutoMapper;
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
    public class TrainsController : Controller
    {
        private readonly ITrainService _trainService;
        private readonly IMapper _mapper;

        public TrainsController(ITrainService trainService, IMapper mapper)
        {
            this._trainService = trainService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var trainsDTO = await _trainService.GetAllAsync();
            var trainsVM = Mapper.Map<IEnumerable<TrainDTO>, IEnumerable<TrainVM>>(trainsDTO);
            return trainsVM;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var trainsDTO = await _trainService.GetByIdAsync(id);
            var trainsVM = Mapper.Map<TrainDTO, TrainVM>(trainsDTO);

            if (trainsVM == null)
            {
                return NotFound();
            }

            return new ObjectResult(trainsVM);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TrainVM trainVM)
        {
            if (trainVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var trainDTO = Mapper.Map<TrainVM, TrainDTO>(trainVM);
                await _trainService.CreateAsync(trainDTO);
                return Ok(trainVM);
            }
            catch (BusinessLogicException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);

            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TrainVM trainVM)
        {
            if (trainVM == null)
            {
                ModelState.AddModelError("", "Не указаны данные");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var trainDTO = Mapper.Map<TrainVM, TrainDTO>(trainVM);
                await _trainService.UpdateAsync(trainDTO);
                return Ok(trainVM);
            }
            catch (BusinessLogicException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);

            }
            return BadRequest();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var trainDTO = await _trainService.GetByIdAsync(id);
            if (trainDTO == null)
            {
                return NotFound();
            }

            try
            {
                var trainVM = Mapper.Map<TrainDTO, TrainVM>(trainDTO);
                await _trainService.DeleteAsync(id);
                return Ok(trainVM);
            }
            catch (BusinessLogicException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);

            }
            return BadRequest();
        }
    }
}
