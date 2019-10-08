using System;

namespace Boffins.ExtensionsNet 
{
    public static class DateTimeExtensions 
    {
        public static bool IsNotMinDate(this DateTime? dateTime) 
        {
            return dateTime.HasValue && dateTime > DateTime.MinValue;
        }
    }
}