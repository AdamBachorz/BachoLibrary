using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachorzLibrary.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsFromPast(this DateTime? dateTime)
        {
            if (!dateTime.HasValue) 
            {
                return true;
            }

            var targetDate = dateTime.Value.Date;
            var currentDate = DateTime.Now.Date;
            return DateTime.Compare(currentDate, targetDate) == 1;
        }

        public static bool IsFromFuture(this DateTime? dateTime) => !IsFromPast(dateTime);

        public static int TimeDifferenceInSec(this DateTime? dateTime, DateTime destinationDateTime)
        {
            return (int)(destinationDateTime - dateTime).Value.TotalSeconds;
        }
        public static int TimeDifferenceInSec(this DateTime? dateTime) => TimeDifferenceInSec(dateTime, DateTime.Now);

        public static bool IsBetween(this DateTime dateTime, DateTime startDate, DateTime endDate, bool includeLeftBound, bool includeRightBound)
        {
            var left = includeLeftBound ? dateTime >= startDate : dateTime > startDate;
            var right = includeRightBound ? dateTime <= endDate : dateTime < endDate;
            return left && right;
        }

        public static DateTime UsingFormat(this DateTime dateTime, string dateFormat)
        {
            try
            {
                var dateString = dateTime.ToString(dateFormat);
                return DateTime.Parse(dateString);
            }
            catch
            {
                return dateTime;
            }
        }

        public static int DaySpan(this DateTime fromDate, DateTime toDate, bool excludeWeekends, IList<Tuple<int, int>> excludeDates = null)
        {
            if (fromDate.CompareTo(toDate) == 0)
            {
                return 1;
            }

            if (fromDate.CompareTo(toDate) > 0)
            {
                var tmp = fromDate;
                fromDate = toDate;
                toDate = tmp;
            }// TODO Cover with tests

            var count = 0;
            for (DateTime index = fromDate; index <= toDate; index = index.AddDays(1))
            {
                if (!excludeWeekends || index.DayOfWeek == DayOfWeek.Saturday || index.DayOfWeek == DayOfWeek.Sunday) 
                { 
                    continue; 
                }
                var excluded = excludeDates?.Any(t => index.Date.Day == t.Item1 && index.Date.Month == t.Item2) ?? false;
                if (!excluded)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
