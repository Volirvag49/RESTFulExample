using RESTFulExample.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace RESTFulExample.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
