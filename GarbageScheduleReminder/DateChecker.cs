using Nager.Date;
using System;
using System.Linq;
namespace GarbageScheduleReminder
{
    public class DateChecker
    {
        private readonly DateTime _dateToday;
        public DateChecker(DateTime dateToday)
        {
            _dateToday = dateToday;
        }
        private readonly int EveryOtherWeek = 14;
        private readonly DateTime FirstWeekOfRecycling = new DateTime(2021, 01, 01);


        public bool IsRecyclingDay()
        {
            var differenceInDays = _dateToday.Subtract(FirstWeekOfRecycling).Days;
            return differenceInDays % EveryOtherWeek == 0;
        }

        public HolidayResult GetHoliday()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(_dateToday.Year, CountryCode.US);

            var currentDate = _dateToday;
            var beginningOfWeek = currentDate.AddDays(-5);
            var endOfWeek = beginningOfWeek.AddDays(6);

            foreach (var publicHoliday in publicHolidays)
            {
                if (publicHoliday.Date >= beginningOfWeek && publicHoliday.Date <= endOfWeek)
                {
                    if (new[] { "Memorial Day", "Thanksgiving Day", "Christmas Day", "Independence Day", "Labour Day", "New Year's Day" }.Contains(publicHoliday.Name))
                        return new HolidayResult { Name = publicHoliday.Name, Date = publicHoliday.Date };
                }
            }

            return null;
        }
    }
}
