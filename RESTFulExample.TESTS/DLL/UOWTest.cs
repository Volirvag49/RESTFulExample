using RESTFulExample.DAL.EF;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTFulExample.TEST;

namespace RESTFulExample.TESTS.DLL
{
    [TestClass]
    public class UOWTest
    {
        DbContextOptionsBuilder<ApplicationDBContext> builder;
        ApplicationDBContext db;
        UnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase(databaseName:
                     "TestDB");
            db = new ApplicationDBContext(builder.Options);
            InitDB.InitDbContext(db);
            unitOfWork = new UnitOfWork(db);
        }

        [TestMethod]
        public async Task Employees_GetAllAsync()
        {
            // Arrange            
            // Act
            var result = await unitOfWork.Employees.GetAllAsync();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }
    }
}
