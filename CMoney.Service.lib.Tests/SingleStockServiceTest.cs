using System;
using System.Collections.Generic;
using CMoney.DataAccess.Lib.Interface;
using CMoney.DataAccess.Lib.Models;
using CMoney.Service.Lib.SingleStockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CMoney.Service.lib.Tests
{
    [TestClass]
    public class SingleStockServiceTest
    {
        [TestMethod]
        public void Create_mockEntity_新增資料成功()
        {
            var mockEntity = new List<SingleStock>()
            {
                new SingleStock
                {
                    Id = Guid.NewGuid(),
                    SecuritiesCode = "6666",
                    SecuritiesName = "Mickey",
                    YieldRate = null,
                    DividendYear = 108,
                    Peratio = null,
                    PriceRatio = 0,
                    FinancialYear = "109/3",
                    ByDate = DateTime.Today
                }
            };

            IRepository<SingleStock> repository = Substitute.For<IRepository<SingleStock>>();
            var service = Substitute.For<SingleStockService>(repository);
            service.Create(mockEntity);
            repository.Received(1).CreateRange(mockEntity);
        }
    }
}
