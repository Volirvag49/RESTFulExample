using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RESTFulExample.DAL.EF;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.BLL.Services;
using RESTFulExample.DAL.Interfaces;
using RESTFulExample.DAL.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace RESTFulExample.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "RESTFulExample API",
                    Description = "Тестовое задание: Реализовать сервис корзины.",
                    TermsOfService = "None",
                });

            });

            services.AddAutoMapper();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IAirService, AirIService>();
            services.AddTransient<ITrainService, TrainService>();
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<ICartService, CartService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDBContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                DbInitializer.Initialize(context);
            }

        }
    }
}
