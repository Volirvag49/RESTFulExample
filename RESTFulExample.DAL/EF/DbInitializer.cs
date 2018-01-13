using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.EF;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RESTFulExample.DAL.EF
{
    public static class DbInitializer
    {

        public static void Initialize(ApplicationDBContext db)
        {

            db.Database.EnsureCreated();

            if (!db.Employees.Any())
            {
                AddEmployee(db);
            }

            if (!db.Airs.Any())
            {
                AddAirs(db);
            }

            if (!db.Trains.Any())
            {
                AddTrains(db);
            }

            if (!db.Hotels.Any())
            {
                AddHotels(db);
            }
        }

        private static void AddEmployee(ApplicationDBContext db)
        {
            db.Employees.Add(new Employee { FirstName = "Fname1", LastName = "Lname1" });
            db.Employees.Add(new Employee { FirstName = "Fname2", LastName = "Lname2" });
            db.Employees.Add(new Employee { FirstName = "Fname3", LastName = "Lname3" });
            db.Employees.Add(new Employee { FirstName = "Fname4", LastName = "Lname4" });
            db.SaveChanges();

        }
        private static void AddAirs(ApplicationDBContext db)
        {
            db.Airs.Add(new Air
            {
                ArrivalAirport = "ArrivalAirport1",
                ArrivalDate = DateTime.Today,
                DepartureAirport = "DepartureAirport1",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 1
            });

            db.Airs.Add(new Air
            {
                ArrivalAirport = "ArrivalAirport2",
                ArrivalDate = DateTime.Today,
                DepartureAirport = "DepartureAirport2",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 2
            });

            db.Airs.Add(new Air
            {
                ArrivalAirport = "ArrivalAirport3",
                ArrivalDate = DateTime.Today,
                DepartureAirport = "DepartureAirport3",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 3
            });

            db.SaveChanges();
        }
        private static void AddTrains(ApplicationDBContext db)
        {
            db.Trains.Add(new Train
            {
                ArrivalStation = "ArrivalStation1",
                ArrivalDate = DateTime.Today,
                DepartureStation = "DepartureStation1",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 1
            });

            db.Trains.Add(new Train
            {
                ArrivalStation = "ArrivalStation2",
                ArrivalDate = DateTime.Today,
                DepartureStation = "DepartureStation2",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 2
            });
            db.Trains.Add(new Train
            {
                ArrivalStation = "ArrivalStation3",
                ArrivalDate = DateTime.Today,
                DepartureStation = "DepartureStation3",
                DepartureDate = DateTime.Today,
                Provider = "Provider1",
                TravellerId = 3

            });

            db.SaveChanges();
        }
        private static void AddHotels(ApplicationDBContext db)
        {
            db.Hotels.Add(new Hotel
            {
                Checkin = DateTime.Today,
                Checkout = DateTime.Today,
                Name = "Hotel 1",
                Provider = "1",
                TravellerId = 1
            });

            db.Hotels.Add(new Hotel
            {
                Checkin = DateTime.Today,
                Checkout = DateTime.Today,
                Name = "Hotel 2",
                Provider = "1",
                TravellerId = 2
            });

            db.Hotels.Add(new Hotel
            {
                Checkin = DateTime.Today,
                Checkout = DateTime.Today,
                Name = "Hotel 3",
                Provider = "1",
                TravellerId = 3
            });

            db.SaveChanges();
        }

    }
}
