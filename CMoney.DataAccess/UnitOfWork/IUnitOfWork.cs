using System;

namespace CMoney.DataAccess.Lib.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChange();
    }
}
