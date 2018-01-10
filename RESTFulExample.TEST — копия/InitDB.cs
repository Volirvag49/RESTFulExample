using RESTFulExample.DAL.EF;
using RESTFulExample.DAL.Entities;

namespace RESTFulExample.TEST
{
    public class InitDB
    {
        public static void InitDbContext(ApplicationDBContext context)
        {

            context.Employees.Add(new Employee { FirstName = "Fname1", LastName = "Lname1" });
            context.Employees.Add(new Employee { FirstName = "Fname2", LastName = "Lname2" });
            context.Employees.Add(new Employee { FirstName = "Fname3", LastName = "Lname3" });
            context.Employees.Add(new Employee { FirstName = "Fname4", LastName = "Lname4" });
            context.SaveChanges();
        }
    }
}
