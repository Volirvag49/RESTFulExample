using RESTFulExample.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace RESTFulExample.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IServiceRepository<Air> Airs { get; }
        IServiceRepository<Train> Trains { get; }
        IServiceRepository<Hotel> Hotels { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Basket> Baskets { get; }

        Task CommitAsync();
    }
}
