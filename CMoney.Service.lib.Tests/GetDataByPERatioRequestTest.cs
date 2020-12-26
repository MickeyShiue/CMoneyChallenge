using System;
using CMoney.Service.Lib.DTO.ApiRequestDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMoney.Service.lib.Tests
{
    [TestClass]

    public class GetDataByPeRatioRequestTest
    {
        [TestMethod]
        public void 傳入錯誤日期_驗證失敗()
        {
            var mockData = new GetDataByPeRatioRequest() { Date = DateTime.Today.AddDays(3) };
            var ex = Assert.ThrowsException<Exception>(() => mockData.CustomValidator());
            var expected = "特定日期不能是未來日期";
            Assert.AreEqual(expected, ex.Message);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void 傳入錯誤排名_驗證失敗(int topN)
        {
            var mockData = new GetDataByPeRatioRequest() { TopN = topN };
            var ex = Assert.ThrowsException<Exception>(() => mockData.CustomValidator());
            var expected = "排名不能是 0 或是負數";
            Assert.AreEqual(expected, ex.Message);
        }

        [TestMethod]
        public void 傳入正常資料_驗證成功()
        {
            var mockData = new GetDataByPeRatioRequest() { Date = DateTime.Today, TopN = 3 };
            var actual = mockData.CustomValidator();
            Assert.AreEqual(true, actual);
        }
    }
}
