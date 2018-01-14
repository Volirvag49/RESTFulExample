using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulExample.API.Util;
using RESTFulExample.BLL.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;
using RESTFulExample.DAL.Mongo;
using RESTFulExample.BLL.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    [ExceptionLoggerFilter]
    public class LoggerTestController : Controller
    {

        // GET: api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string Message)
        {
            throw new BusinessLogicException("Тестовое  исключение: " + Message, "Тест");
        }      
    }
}
