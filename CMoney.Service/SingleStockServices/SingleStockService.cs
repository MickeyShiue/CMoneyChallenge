using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CMoney.DataAccess.Lib.Interface;
using CMoney.DataAccess.Lib.Models;

namespace CMoney.Service.Lib.SingleStockServices
{
    public class SingleStockService : ISingleStockService
    {
        private readonly IRepository<SingleStock> _singleStockRepository;
        private readonly CmoneyContext _context;

        public SingleStockService(CmoneyContext context, IRepository<SingleStock> singleStockRepository)
        {
            this._context = context;
            this._singleStockRepository = singleStockRepository;
        }

        public IEnumerable<SingleStock> GetAll(Expression<Func<SingleStock, bool>> filter = null,
            Func<IQueryable<SingleStock>, IOrderedQueryable<SingleStock>> orderBy = null)
        {
            return this._singleStockRepository.Find(filter, orderBy);
        }

        public void Create(IEnumerable<SingleStock> singleStocks)
        {
            this._singleStockRepository.CreateRange(singleStocks);
        }
    }
}
