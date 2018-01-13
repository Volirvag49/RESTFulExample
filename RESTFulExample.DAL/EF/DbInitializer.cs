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

            if (!db.Carts.Any())
            {
                AddCarts(db);
            }
        }

        private static void AddEmployee(ApplicationDBContext db)
        {
            db.Employees.Add(new Employee { FirstName = "Fname1", LastName = "Lname1" });
            db.Employees.Add(new Employee { FirstName = "Fname2", LastName = "Lname2" });
            db.Employees.Add(new Employee { FirstName = "Fname3", LastName = "Lname3" });
            db.Employees.Add(new Employee { FirstName = "Fname4", LastName = "Lname4" });
            db.Employees.Add(new Employee { FirstName = "Fname5", LastName = "Lname5" });
            db.SaveChanges();

        }
        private static void AddAirs(ApplicationDBContext db)
        {
            db.Airs.Add(new Air
            {
                Id = "9ffdfb66-d97c-460f-8077-5f954239b0f6",
                ArrivalAirport = "ArrivalAirport1",
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartureAirport = "DepartureAirport1",
                DepartureDate = DateTime.Now.AddDays(1).AddHours(8),
                Provider = "Provider1",
                TravellerId = 1
            });

            db.Airs.Add(new Air
            {
                Id = "8a970bb1-b333-4a0e-ab41-93ea38601591",
                ArrivalAirport = "ArrivalAirport2",
                ArrivalDate = DateTime.Now.AddDays(2),
                DepartureAirport = "DepartureAirport2",
                DepartureDate = DateTime.Now.AddDays(2).AddHours(8),
                Provider = "Provider1",
                TravellerId = 2
            });

            db.Airs.Add(new Air
            {
                Id = "d5d2483f-1aad-404d-b797-088824ae3673",
                ArrivalAirport = "ArrivalAirport3",
                ArrivalDate = DateTime.Now.AddDays(3),
                DepartureAirport = "DepartureAirport3",
                DepartureDate = DateTime.Now.AddDays(3).AddHours(8),
                Provider = "Provider1",
                TravellerId = 3
            });

            db.Airs.Add(new Air
            {
                Id = "48b1723e-1f06-4c3a-b070-e14fa538929d",
                ArrivalAirport = "ArrivalAirport4",
                ArrivalDate = DateTime.Now.AddDays(4),
                DepartureAirport = "DepartureAirport4",
                DepartureDate = DateTime.Now.AddDays(4).AddHours(8),
                Provider = "Provider1",
            });

            db.Airs.Add(new Air
            {
                Id = "68ca4f27-e603-4b03-bad3-f90cc99df59e",
                ArrivalAirport = "ArrivalAirport5",
                ArrivalDate = DateTime.Now.AddDays(5),
                DepartureAirport = "DepartureAirport5",
                DepartureDate = DateTime.Now.AddDays(5).AddHours(8),
                Provider = "Provider1",
            });


            db.SaveChanges();
        }
        private static void AddTrains(ApplicationDBContext db)
        {
            db.Trains.Add(new Train
            {
                Id = "01179667-eb83-4650-9f72-a09ae4350c98",
                ArrivalStation = "ArrivalStation1",
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartureStation = "DepartureStation1",
                DepartureDate = DateTime.Now.AddDays(1).AddHours(8),
                Provider = "Provider1",
                TravellerId = 1
            });

            db.Trains.Add(new Train
            {
                Id = "3832152b-f8f9-47af-81ba-1983216028fb",
                ArrivalStation = "ArrivalStation2",
                ArrivalDate = DateTime.Now.AddDays(2),
                DepartureStation = "DepartureStation2",
                DepartureDate = DateTime.Now.AddDays(2).AddHours(8),
                Provider = "Provider1",
                TravellerId = 2
            });

            db.Trains.Add(new Train
            {
                Id = "62452bbb-f24f-4ecd-998c-9b622e16171d",
                ArrivalStation = "ArrivalStation3",
                ArrivalDate = DateTime.Now.AddDays(3),
                DepartureStation = "DepartureStation1",
                DepartureDate = DateTime.Now.AddDays(3).AddHours(8),
                Provider = "Provider1",
            });

            db.Trains.Add(new Train
            {
                Id = "e083510c-9638-48d0-a4d9-b591bb919979",
                ArrivalStation = "ArrivalStation4",
                ArrivalDate = DateTime.Now.AddDays(4),
                DepartureStation = "DepartureStation4",
                DepartureDate = DateTime.Now.AddDays(4).AddHours(8),
                Provider = "Provider1",
            });

            db.Trains.Add(new Train
            {
                Id = "1d34397c-364a-47be-abfa-328cd96dee83",
                ArrivalStation = "ArrivalStation5",
                ArrivalDate = DateTime.Now.AddDays(5),
                DepartureStation = "DepartureStation4",
                DepartureDate = DateTime.Now.AddDays(5).AddHours(8),
                Provider = "Provider1",
            });

            db.SaveChanges();
        }
        private static void AddHotels(ApplicationDBContext db)
        {
            db.Hotels.Add(new Hotel
            {
                Id = "ddf60ebf-ebaa-4266-b4bf-7fd3bcbfd2a1",
                Checkin = DateTime.Today.AddDays(1),
                Checkout = DateTime.Today.AddDays(2),
                Name = "Hotel 1",
                Provider = "Provider2",
                TravellerId = 1
            });

            db.Hotels.Add(new Hotel
            {
                Id = "72f19357-aaaf-4a62-bcbf-fa9f23c13125",
                Checkin = DateTime.Today.AddDays(1),
                Checkout = DateTime.Today.AddDays(2),
                Name = "Hotel 2",
                Provider = "Provider2",
                TravellerId = 2
            });

            db.Hotels.Add(new Hotel
            {
                Id = "90e93424-951d-4a32-a7a0-aac8c0aaeb89",
                Checkin = DateTime.Today.AddDays(1),
                Checkout = DateTime.Today.AddDays(2),
                Name = "Hotel 3",
                Provider = "Provider2",
            });

            db.Hotels.Add(new Hotel
            {
                Id = "aa50a3d4-3976-4d40-8fe3-5e2ad9954d91",
                Checkin = DateTime.Today.AddDays(1),
                Checkout = DateTime.Today.AddDays(2),
                Name = "Hotel 4",
                Provider = "Provider2",
            });

            db.Hotels.Add(new Hotel
            {
                Id = "83e889d7-3093-4d11-a65e-f4f289f3c6bd",
                Checkin = DateTime.Today.AddDays(1),
                Checkout = DateTime.Today.AddDays(2),
                Name = "Hotel 5",
                Provider = "Provider2",
            });

            db.SaveChanges();
        }

        private static void AddCarts(ApplicationDBContext db)
        {
            db.Carts.Add(new Cart
            {
                EmployeeId = 1,
                AirId = "9ffdfb66-d97c-460f-8077-5f954239b0f6"
            });
            db.Carts.Add(new Cart
            {
                EmployeeId = 2,
                AirId = "8a970bb1-b333-4a0e-ab41-93ea38601591"
            });
            db.Carts.Add(new Cart
            {
                EmployeeId = 3,
                AirId = "d5d2483f-1aad-404d-b797-088824ae3673"
            });

            db.Carts.Add(new Cart
            {
                EmployeeId = 1,
                TrainId = "01179667-eb83-4650-9f72-a09ae4350c98"
            });
            db.Carts.Add(new Cart
            {
                EmployeeId = 2,
                TrainId = "3832152b-f8f9-47af-81ba-1983216028fb"
            });

            db.Carts.Add(new Cart
            {
                EmployeeId = 1,
                HotelId = "ddf60ebf-ebaa-4266-b4bf-7fd3bcbfd2a1"
            });
            db.Carts.Add(new Cart
            {
                EmployeeId = 2,
                HotelId = "72f19357-aaaf-4a62-bcbf-fa9f23c13125"
            });

            db.SaveChanges();
        }

    }
}
