namespace CMoney.Service.Lib.Extension
{
    public static class StringExt
    {
        public static string[] CustomSplit(this string target)
        {
            return target.Replace("\"", "").TrimEnd(',').Split(',');
        }
    }
}
