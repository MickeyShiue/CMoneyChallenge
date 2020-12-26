using System.Linq;
using CMoney.Service.Lib.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMoney.Service.lib.Tests
{
    [TestClass]
    public class StrictlyHelperTest
    {
        [TestMethod]
        [DataRow(new int[] { 1, 3, 3, 4, 5, 6 }, 2, 5)]
        [DataRow(new int[] { 1, 2, 4, 1, 2, 3, 5, 6, 5, 6, 7, 8, 9, 23 }, 8, 13)]
        public void StrictlyIncreasing_嚴格遞增測試(int[] targetData, int lowPoint, int highPoint)
        {
            var result = StrictlyHelper.StrictlyIncreasing(targetData.Select(x => (decimal?) x).ToList());

            Assert.AreEqual(result.lowPoint, lowPoint);
            Assert.AreEqual(result.highPoint, highPoint);
        }
    }
}
