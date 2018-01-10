using System;
using System.Threading.Tasks;
using RESTFulExample.DAL.EF;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;


namespace RESTFulExample.DAL.Repositories
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext dbContext;
     
        public UnitOfWork(ApplicationDBContext context)
        {
            dbContext = context;
        }
      
        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        // IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
