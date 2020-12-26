using System;
using CMoney.DataAccess.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace CMoney.DataAccess.Lib.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed = false;

        public UnitOfWork(CmoneyContext context)
        {
            this._context = context;
        }

        public int SaveChange()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
