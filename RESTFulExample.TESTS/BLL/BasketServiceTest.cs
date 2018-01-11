using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Services;
using RESTFulExample.DAL.EF;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace RESTFulExample.TEST.DLL
{
    [TestClass]
    public class BasketServiceTest
    {
        DbContextOptionsBuilder<ApplicationDBContext> builder;
        ApplicationDBContext db;
        UnitOfWork unitOfWork;
        BasketService basketService;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase(databaseName:
                     "TestDB");
            db = new ApplicationDBContext(builder.Options);
            InitDB.InitDbContext(db);
            unitOfWork = new UnitOfWork(db);
            basketService = new BasketService(unitOfWork);
            Mapper.Initialize(cfg => cfg.CreateMap<Basket, BasketDTO>());
        }

        [TestMethod]
        public async Task Baskets_GetByIdAsync()
        {
            // Arrange            
            // Act
            var result = await basketService.FindByEmpIdAsync(3) as IList;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public async Task Baskets_AddAir()
        {
            // Arrange            
            int empId = 1;
            string airId = "Air111";
            // Act
            await basketService.AddAirAsync(empId, airId);

            var basketIsExist = await unitOfWork.Baskets.IsExistAsync(where: q => q.EmployeeId == empId  && q.AirId == airId);

            Expression<Func<Basket, bool>> searchQuery = q => q.EmployeeId == empId;
            var baskets = await basketService.FindByEmpIdAsync(empId);
            // Assert
            Assert.IsNotNull(basketIsExist);

            Assert.IsNotNull(baskets);
        }

    }
}
