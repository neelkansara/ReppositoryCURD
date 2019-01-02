using CURD.Contract.Repository;
using CURD.DAL.Repository;
using CURD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly TestDB_1Entities _context = new TestDB_1Entities();
        private bool _disposed;

        public IUerRepository UserRepository { get; }
        public UnitOfWork()
        {
            UserRepository = new UserRepository(_context);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
