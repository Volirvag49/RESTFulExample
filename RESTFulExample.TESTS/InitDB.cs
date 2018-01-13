using RESTFulExample.DAL.EF;
using RESTFulExample.DAL.Entities;
using System;

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

            context.Airs.Add(new Air
            {
                Id = "Air111",
                ArrivalAirport = "ArrivalAirport1",
                ArrivalDate = DateTime.Today,
                DepartureAirport = "DepartureAirport1",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 1

            });

            context.Airs.Add(new Air
            {
                Id = "Air222",
                ArrivalAirport = "ArrivalAirport2",
                ArrivalDate = DateTime.Today,
                DepartureAirport = "DepartureAirport2",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 2

            });

            context.Airs.Add(new Air
            {
                Id = "Air333",
                ArrivalAirport = "ArrivalAirport3",
                ArrivalDate = DateTime.Today,
                DepartureAirport = "DepartureAirport3",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 3

            });

            context.Trains.Add(new Train
            {
                Id = "Train1",
                ArrivalStation = "ArrivalStation1",
                ArrivalDate = DateTime.Today,
                DepartureStation = "DepartureStation1",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 1

            });

            context.Trains.Add(new Train
            {
                Id = "Train2",
                ArrivalStation = "ArrivalStation2",
                ArrivalDate = DateTime.Today,
                DepartureStation = "DepartureStation2",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 2

            });

            context.Trains.Add(new Train
            {
                Id = "Train3",
                ArrivalStation = "ArrivalStation3",
                ArrivalDate = DateTime.Today,
                DepartureStation = "DepartureStation3",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 3

            });

            context.Hotels.Add(new Hotel
            {
                Id = "Hotel1",
                Checkin = DateTime.Today,
                Checkout = DateTime.Today,
                Name="Hotel 1",
                Provider = "1",
                TravellerId = 1

            });

            context.Hotels.Add(new Hotel
            {
                Id = "Hotel2",
                Checkin = DateTime.Today,
                Checkout = DateTime.Today,
                Name = "Hotel 2",
                Provider = "1",
                TravellerId = 2

            });

            context.Hotels.Add(new Hotel
            {
                Id = "Hotel3",
                Checkin = DateTime.Today,
                Checkout = DateTime.Today,
                Name = "Hotel 3",
                Provider = "1",
                TravellerId = 3

            });

            context.Baskets.Add(new Cart
            {
                 EmployeeId = 3,
                 AirId = "Air333",
            });

            context.SaveChanges();
        }
    }
}
