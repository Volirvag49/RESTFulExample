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
using RESTFulExample.DAL.Mongo;
using RESTFulExample.API.Util;

namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    [ExceptionLoggerFilter]
    public class LoggerController : Controller
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public LoggerController(ILogService logService, IMapper mapper )
        {
            this._logService = logService;
            this._mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            var logDTO = await _logService.GetAllLogsAsync();
            return logDTO;
        }

        // GET api/values/5
        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
             await _logService.RemoveAllLogs();

            return Ok();
        }


    }
}
