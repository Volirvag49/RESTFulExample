using RESTFulExample.DAL.Entities;
using System;
using System.Linq;

namespace RESTFulExample.DAL.EF
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            //context.Database.EnsureCreated();

            //if (context.Users.Any())
            //{
            //    return;   
            //}

            //var users = new User[]
            //{
            //    new User{Login = "111111", Password = "111111", Miner= "e6b821fb8bc6df40b922a82bdf78925bcff29d67"}
            //};

            //foreach (User u in users)
            //{
            //    context.Users.Add(u);
            //}
            //context.SaveChanges();
        }
    }
}
