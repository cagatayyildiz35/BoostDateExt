using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boost.DateTimeExtension
{
   public static class BoostDate
    {

       public static bool IsWeekDay(DateTime currenttime)
        {
            bool isweekday = true;
            int day = Convert.ToInt32(currenttime.DayOfWeek);

            if (day == 0 || day == 6)
            {
                isweekday = false;
            }
            return isweekday;
        }

        // get first day of the month
        public static DateTime GetFirstDayOfMonth()
        {
            DateTime currenttime = DateTime.Now;
            DateTime day = new DateTime(currenttime.Year, currenttime.Month, 1);
            return day;
        }

        // get last day of the month
        public static DateTime LastDayOfMonth()
        {
            DateTime currenttime = DateTime.Now;
            DateTime firstday = new DateTime(currenttime.Year, currenttime.Month, 1);
            DateTime nextmonthfirstday = new DateTime(currenttime.Year, currenttime.Month + 1, 1);

            TimeSpan ts = nextmonthfirstday - firstday;
            int day = ts.Days;

            DateTime lastdayofmonth = new DateTime(currenttime.Year, currenttime.Month, day);
            return lastdayofmonth;
        }

        // get last workday of month
        public static DateTime LastWorkdayOfMonth()
        {
            DateTime currenttime = DateTime.Now;
            DateTime firstdayofmonth = new DateTime(currenttime.Year, currenttime.Month, 1);
            DateTime nextmonthfirstday = new DateTime(currenttime.Year, currenttime.Month + 1, 1);
            TimeSpan dayrange = nextmonthfirstday - firstdayofmonth;

            int days = dayrange.Days;

            DateTime result = DateTime.Now;
            for (int i = days; true; i--)
            {
                DateTime tempdate = new DateTime(currenttime.Year, currenttime.Month, i);
                int workday = Convert.ToInt32(tempdate.DayOfWeek);
                if (workday == 5 || workday == 4 || workday == 3 || workday == 2 || workday == 1)
                {
                    result = tempdate;
                    break;
                }
            }
            return result;
        }

        // get first workday date of the week
        public static DateTime FirstWorkdayOfWeek()
        {
            DateTime currenttime = DateTime.Now;
            int currentday = Convert.ToInt32(currenttime.DayOfWeek);
            if (currentday == 0)
            {
                currentday = 7; // indexing day  issue is solved
            }
            DateTime workday = currenttime.AddDays(1 - currentday);
            return workday;
        }

        // get last workday of the week
        public static DateTime LastWorkdayofWeek()
        {
            DateTime currenttime = DateTime.Now;
            int currentday = Convert.ToInt32(currenttime.DayOfWeek);
            if (currentday == 0)
            {
                currentday = 7; // indexing day  issue is solved
            }
            DateTime workday = currenttime.AddDays(5 - currentday);
            return workday;
        }

        // get first workday of month
        public static DateTime FirstWorkdayMonth()
        {
            DateTime theDate = DateTime.Now;
            DateTime nextMonth = new DateTime(theDate.Year, theDate.Month + 1, 1);
            DayOfWeek DOW = nextMonth.DayOfWeek;
            int dayIndex = Convert.ToInt32(DOW);
            if (dayIndex == 6)
            {
                return nextMonth.AddDays(2);
            }

            if (dayIndex == 0)
            {
                return nextMonth.AddDays(1);
            }
            return nextMonth;
        }

        // add business days to current date
        public static DateTime AddBusinessDays(int workday)
        {
            DateTime currentTime = DateTime.Now;
            DateTime temp = DateTime.Now;

            for (int i = 0; i <= workday; i++)
            {
                temp = currentTime.AddDays(i);
                int dayIndex = Convert.ToInt32(temp.DayOfWeek);
                if (dayIndex == 6 || dayIndex == 0)
                {
                    workday++;
                }
            }
            return temp;
        }

        // Calculate age
        public static int GetAge(DateTime birthdate)
        {
            DateTime currenttime = DateTime.Now;
            TimeSpan ts = currenttime - birthdate;
            int calculateage = (ts.Days) / 365;
            return calculateage;
        }

        // get business days in the month
        public static int GetBusinessDays()
        {
            DateTime currenttime = DateTime.Now;
            DateTime firstday = new DateTime(currenttime.Year, currenttime.Month, 1);
            DateTime nextmonthfirstday = new DateTime(currenttime.Year, currenttime.Month + 1, 1);

            TimeSpan ts = nextmonthfirstday - firstday;
            int days = ts.Days;
            int businessday = days;

            for (int i = 1; i < days; i++)
            {
                DateTime tempdate = new DateTime(currenttime.Year, currenttime.Month, i);
                int day = Convert.ToInt32(tempdate.DayOfWeek);

                if (day == 0 || day == 6)
                {
                    businessday--;
                }
            }
            return businessday;
        }

        // get available business days of given date
        public static int GetBusinessDayss(DateTime givendate)
        {
            givendate = DateTime.Now;
            DateTime firstday = new DateTime(givendate.Year, givendate.Month, 1);
            DateTime nextmonthfirstday = new DateTime(givendate.Year, givendate.Month + 1, 1);

            TimeSpan ts = nextmonthfirstday - firstday;
            int days = ts.Days;
            int businessday = days;

            for (int i = 1; i < days; i++)
            {
                DateTime tempdate = new DateTime(givendate.Year, givendate.Month, i);
                int day = Convert.ToInt32(tempdate.DayOfWeek);

                if (day == 0 || day == 6)
                {
                    businessday--;
                }
            }
            return businessday;
        }

        // get next first day of next week
        public static DateTime NextWorkday(DateTime givendate)
        {
            int day = Convert.ToInt32(givendate.DayOfWeek);
            if (day == 0)
            {
                day = 7; // indexing dayofweek method issue is solved
            }
            DateTime businessday = givendate.AddDays(7 - (day - 1));
            return businessday;
        }


        // get last business day of the week

        public static DateTime LastWorkdayofWeekk(DateTime currenttime)
        {
            int currentday = Convert.ToInt32(currenttime.DayOfWeek);
            if (currentday == 0)
            {
                currentday = 7; // indexing day  issue is solved
            }
            DateTime workday = currenttime.AddDays(5 - currentday);
            return workday;
        }

        // get quarters of given year

        public static DateTime GetQuarters(int quarter, int year)
        {
            DateTime quarterdate = new DateTime(year, (quarter - 1) * +1, 1);
            return quarterdate;
        }

        // get total days between given two dates
        public static int TotalDays(DateTime d1, DateTime d2)
        {
            TimeSpan ts = d1 - d2;
            return ts.Days;
        }

        // get total hours between given two dates
        public static int TotalHours(DateTime d1, DateTime d2)
        {
            TimeSpan ts = d1 - d2;
            return Convert.ToInt32(ts.TotalHours);
        }


        // get business days between two given dates
        public static int TotalBusinessDays(DateTime d1, DateTime d2)
        {
            TimeSpan ts = d2 - d1;
            int alldays = ts.Days;
            int businessday = alldays;
            for (int i = 0; i < alldays; i++)
            {
                DateTime tempdate = d1.AddDays(i);
                int dayindex = Convert.ToInt32(tempdate.DayOfWeek);
                if (dayindex == 0 || dayindex == 6)
                {
                    businessday--;
                }
            }
            return businessday;
        }


        // get holidays beetween two given dates
        public static int GetHolidays(DateTime d1, DateTime d2)
        {
            TimeSpan ts = d2 - d1;
            int alldays = ts.Days;
            int businessday = 0;
            for (int i = 0; i < alldays; i++)
            {
                DateTime tempdate = d1.AddDays(i);
                int dayindex = Convert.ToInt32(tempdate.DayOfWeek);
                if (dayindex == 0 || dayindex == 6)
                {
                    businessday++;
                }
            }
            return businessday;
        }

        // get last second of given date
        public static DateTime GetLastSec(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }


        // get first second of given date
        public static DateTime GetFirstSec(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 1);
        }

        // check whether the given date is holiday
        public static bool IsHoliday(DateTime date)
        {
            bool isholiday = false;
            int dayindex = Convert.ToInt32(date.DayOfWeek);
            if (dayindex == 0 || dayindex == 6)
            {
                isholiday = true;
            }
            return isholiday;
        }

        // countdown
        public static string Countdown(DateTime date)
        {
            string span = "";
            DateTime now = DateTime.Now;
            TimeSpan ts = date - now;
            if (ts.Days != 0)
            {
                span = span + ts.Days + "Gün ";
            }
            if (ts.Hours != 0)
            {
                span = span + ts.Hours + "Saat ";
            }
            if (ts.Minutes != 0)
            {
                span = span + ts.Minutes + "Dakika ";
            }
            if (ts.Seconds != 0)
            {
                span = span + ts.Minutes + "Saniye ";
            }
            return span;
        }
    }
}
