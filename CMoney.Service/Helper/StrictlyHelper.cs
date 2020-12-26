using System.Collections.Generic;
using System.Linq;

namespace CMoney.Service.Lib.Helper
{
    /// <summary>
    /// 嚴格類別 => 嚴格遞增、嚴格遞減
    /// </summary>
    public static class StrictlyHelper
    {
        public static (int lowPoint, int highPoint) StrictlyIncreasing(List<decimal?> targetData)
        {
            var tempLowPoint = 0;
            var tempHighPoint = 0;
            var lowPoint = 0;
            var highPoint = 0;

            if (!targetData.Any()) { return (0, 0); };

            for (var i = 1; i < targetData.Count(); ++i)
            {
                if (targetData[i] > targetData[i - 1]) tempHighPoint = i;

                if (!(targetData[i] <= targetData[i - 1]) && i != targetData.Count() - 1) continue;

                if (tempHighPoint - tempLowPoint > highPoint - lowPoint)
                {
                    lowPoint = tempLowPoint;
                    highPoint = tempHighPoint;
                }

                tempLowPoint = i;
            }

            return (lowPoint, highPoint);
        }
    }
}
