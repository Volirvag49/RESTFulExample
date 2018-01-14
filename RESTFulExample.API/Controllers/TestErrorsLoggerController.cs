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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTFulExample.API.Controllers
{
    [Route("api/[controller]")]
    [ExceptionLoggerFilter]
    public class TestErrorsLoggerController : Controller
    {

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            int x = 0;
            int y = 7 / x;
            return new string[] { "value1", "value2" };
        }

        
    }
}
