using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using RESTFulExample.API.Models;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Interfaces;
using RESTFulExample.BLL.Services;
using RESTFulExample.DAL.Repositories;
using AutoMapper;
using RESTFulExample.DAL.Mongo;
using Microsoft.Extensions.Options;
using RESTFulExample.DAL.Entities;

namespace RESTFulExample.API.Util
{
    public class ExceptionLoggerFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogRepository _logRepository;

        public ExceptionLoggerFilterAttribute()
        {
            LogSettings settings = new LogSettings()
            {
                ConnectionString = "mongodb://localhost:27017/RESTFullExample",
                Database = "RESTFullExampleLogs"
            };
            _logRepository = new LogRepository(settings);
        }   

        public void OnException(ExceptionContext context)
        {
            //string key = System.Configuration.ConfigurationManager.AppSettings["AppKey"];
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;

            Log logDTO = new Log()
            {
                Method_name = actionName,
                Exception = exceptionMessage,
                Event_date = DateTime.Now
            };

            _logRepository.AddLog(logDTO);

            context.ExceptionHandled = true;

        }
    }
}
