using RESTFulExample.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace RESTFulExample.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Air> Airs { get; }
        IRepository<Train> Trains { get; }
        IRepository<Hotel> Hotels { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Basket> Baskets { get; }

        Task CommitAsync();
    }
}
