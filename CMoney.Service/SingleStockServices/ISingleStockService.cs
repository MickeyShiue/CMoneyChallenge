﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CMoney.DataAccess.Lib.Models;
using CMoney.Service.Lib.DTO.ApiRequestDTO;

namespace CMoney.Service.Lib.SingleStockServices
{
    public interface ISingleStockService
    {
        IEnumerable<SingleStock> GetAll(Expression<Func<SingleStock, bool>> filter = null,
            Func<IQueryable<SingleStock>, IOrderedQueryable<SingleStock>> orderBy = null);

        void Create(IEnumerable<SingleStock> singleStocks);

        bool IsExist(ImportDataByDateRequest request);
    }
}
