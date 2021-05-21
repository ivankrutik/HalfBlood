namespace Buisness.Workflows.Helper
{
    using System;
    using System.Globalization;

    static class DateTimeHelpers
    {
        static public string ShortYear(this string obj)
        {
            return obj + DateTime.Now.Year.ToString(CultureInfo.InvariantCulture).Remove(0, 2);
        }
    }
}
