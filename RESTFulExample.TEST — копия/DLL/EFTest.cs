using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace RESTFulExample.TEST.DLL
{
    [TestClass]
    public class EFTest
    {
        DbContextOptionsBuilder<ApplicationDBContext> builder;
        ApplicationDBContext db = null;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase(databaseName:
                     "TestDB");
            db = new ApplicationDBContext(builder.Options);
            InitDB.InitDbContext(db);
        }

        [TestMethod]
        public void Employees_GetAll()
        {
            // Arrange            
            // Act
            var result = db.Employees.ToListAsync();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Result.Count);
        }
    }
}
