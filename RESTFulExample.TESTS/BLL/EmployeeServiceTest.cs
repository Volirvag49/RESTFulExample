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

namespace RESTFulExample.TEST.DLL
{
    [TestClass]
    public class EmployeeServiceTest
    {
        DbContextOptionsBuilder<ApplicationDBContext> builder;
        ApplicationDBContext db;
        UnitOfWork unitOfWork;
        EmployeeService employeeService;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase(databaseName:
                     "TestDB");
            db = new ApplicationDBContext(builder.Options);
            InitDB.InitDbContext(db);
            unitOfWork = new UnitOfWork(db);
            employeeService = new EmployeeService(unitOfWork);
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
        }

        [TestMethod]
        public async Task Employees_GetAllAsync()
        {
            // Arrange            
            // Act
            var result = await employeeService.GetAllAsync() as IList;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public async Task Employees_Create()
        {
            // Arrange          
            EmployeeDTO newEmployee = new EmployeeDTO()
            {
                FirstName = "newFName1",
                LastName = "newLName1"
            };

            int oldEmpCount = await db.Employees.CountAsync();

            // Act
            await employeeService.CreateAsync(newEmployee);

            var employees = db.Employees.ToList();
            var newEmpList = from e in db.Employees
                             .Where(e => e.FirstName == "newFName1")
                             select e;
            // Assert
            Assert.AreNotEqual(0, newEmpList.Count());
            Assert.AreEqual(oldEmpCount + 1, employees.Count);

        }      

        [TestMethod]
        public async Task Employees_Delete()
        {
            // Arrange          
            int oldEmpCount = await db.Employees.CountAsync();

            // Act
            await employeeService.DeleteAsync(1);

            int newEmpCount = await db.Employees.CountAsync();
            // Assert
            Assert.AreNotEqual(oldEmpCount, newEmpCount - 1);
        }
    }
}
