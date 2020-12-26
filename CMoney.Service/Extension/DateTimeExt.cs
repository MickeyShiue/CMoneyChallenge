using System;

namespace CMoney.Service.Lib.Extension
{
    public static class DateTimeExt
    {
        public static string ToShortDate(this DateTime source)
        {
            return source.ToString("yyyyMMdd");
        }
    }
}
