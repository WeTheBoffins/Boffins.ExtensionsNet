using System;
using System.Collections.Generic;

namespace Boffins.ExtensionsNet
{
    public static class DateTimeExtensions
    {
        public static bool IsNotMinDate(this DateTime? dateTime)
        {
            return dateTime.HasValue && dateTime > DateTime.MinValue;
        }

        public static DateTime FirstDayOfTheMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return date.FirstDayOfTheMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfNextMonth(this DateTime date)
        {
            return date.FirstDayOfTheMonth().AddMonths(1);
        }

        public static bool IsLeapDay(this DateTime date)
        {
            return (date.Month == 2 && date.Day == 29);
        }
        
        public static bool IsLeapYear(this DateTime value)
        {
            return (DateTime.DaysInMonth(value.Year, 2) == 29);
        }
        
        public static int DaysBetweenDates(this DateTime startDate, DateTime endDate)
        {
            return endDate.Subtract(startDate).Days + 1;
        }

        public static TimeSpan TimeElapsed(this DateTime date)
        {
            return DateTime.Now - date;
        }
        
        public static bool IsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }
        
        public static IList<DateTime> MonthsBetweenDates(this DateTime startDate, DateTime endDate)
        {
            var monthList = new List<DateTime>();
            var currentDate = startDate;
            while (currentDate >= startDate && currentDate <= endDate)
            {
                monthList.Add(currentDate.FirstDayOfTheMonth());
                currentDate = currentDate.FirstDayOfNextMonth();
            }

            return monthList;
        }
    }
}