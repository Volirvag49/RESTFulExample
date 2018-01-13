﻿using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;

namespace RESTFulExample.DAL.Repositories
{
    public partial class UnitOfWork
    {
        private IServiceRepository<Air> airRepository;
        private IServiceRepository<Train> trainRepository;
        private IServiceRepository<Hotel> hotelRepository;
        private IRepository<Employee> employeeRepository;
        private IRepository<Cart> cartRepository;


        public IServiceRepository<Air> Airs
        {
            get
            {
                if (airRepository == null)
                {
                    airRepository = new GenericServiceRepository<Air>(dbContext);
                }
                return airRepository;
            }
        }

        public IServiceRepository<Train> Trains
        {
            get
            {
                if (trainRepository == null)
                {
                    trainRepository = new GenericServiceRepository<Train>(dbContext);
                }
                return trainRepository;
            }
        }

        public IServiceRepository<Hotel> Hotels
        {
            get
            {
                if (hotelRepository == null)
                {
                    hotelRepository = new GenericServiceRepository<Hotel>(dbContext);
                }
                return hotelRepository;
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new GenericRepository<Employee>(dbContext);
                }
                return employeeRepository;
            }
        }

        public IRepository<Cart> Carts
        {
            get
            {
                if (cartRepository == null)
                {
                    cartRepository = new GenericRepository<Cart>(dbContext);
                }
                return cartRepository;
            }
        }
    }
}
