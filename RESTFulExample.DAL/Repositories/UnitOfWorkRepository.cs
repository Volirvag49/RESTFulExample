using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;

namespace RESTFulExample.DAL.Repositories
{
    public partial class UnitOfWork
    {
        private IRepository<Air> airRepository;
        private IRepository<Train> trainRepository;
        private IRepository<Hotel> hotelRepository;
        private IRepository<Employee> employeeRepository;
        private IRepository<Basket> basketRepository;

        public IRepository<Air> Airs
        {
            get
            {
                if (airRepository == null)
                {
                    airRepository = new GenericRepository<Air>(dbContext);
                }
                return airRepository;
            }

        }

        public IRepository<Train> Trains
        {
            get
            {
                if (trainRepository == null)
                {
                    trainRepository = new GenericRepository<Train>(dbContext);
                }
                return trainRepository;
            }

        }

        public IRepository<Hotel> Hotels
        {
            get
            {
                if (hotelRepository == null)
                {
                    hotelRepository = new GenericRepository<Hotel>(dbContext);
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

        public IRepository<Basket> Baskets
        {
            get
            {
                if (basketRepository == null)
                {
                    basketRepository = new GenericRepository<Basket>(dbContext);
                }
                return basketRepository;
            }

        }
    }
}
