using System;
using Xunit;

namespace GarbageScheduleReminder.Tests
{
    public class DateCheckerTests
    {
        [Fact]
        public void IsRecyclingDay_ReturnsTrueIfIsRecyclingWeek()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 06, 18);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.IsRecyclingDay();
            Assert.True(actual);
        }

        [Fact]
        public void IsRecyclingDay_ReturnsFalseIfNotRecyclingWeek()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 06, 25);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.IsRecyclingDay();
            Assert.False(actual);
        }

        [Fact]
        public void IsRecyclingDay_ReturnsTrueIfRecyclingWeek_2()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 06, 4);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.IsRecyclingDay();
            Assert.True(actual);
        }

        [Fact]
        public void IsRecyclingDay_ReturnsTrueIfRecyclingWeek_3()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 11, 5);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.IsRecyclingDay();
            Assert.True(actual);
        }

        [Fact]
        public void IsRecyclingDay_ReturnsTrueIfRecyclingWeek_4()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 12, 31);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.IsRecyclingDay();
            Assert.True(actual);
        }

        [Fact]
        public void IsRecyclingDay_ReturnsTrueIfRecyclingWeek_5()
        {
            var today = SystemTime.Now = () => new DateTime(2022, 1, 14);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.IsRecyclingDay();
            Assert.True(actual);
        }

        [Fact]
        public void GetHoliday_ReturnsHolidayIfWithinWeek()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 7, 9);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.GetHoliday();

            Assert.Equal(actual.Name, "Independence Day");
        }

        [Fact]
        public void GetHoliday_ReturnsHolidayIfWithinWeek_2()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 11, 26);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.GetHoliday();

            Assert.Equal(actual.Name, "Thanksgiving Day");
        }

        [Fact]
        public void GetHoliday_ReturnsHolidayIfWithinWeek_3()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 12, 24);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.GetHoliday();

            Assert.Equal(actual.Name, "Christmas Day");
        }

        [Fact]
        public void GetHoliday_ReturnsNoHolidayIfNoneWithinWeek()
        {
            var today = SystemTime.Now = () => new DateTime(2021, 10, 15);
            var dateChecker = new DateChecker(today.Invoke());

            var actual = dateChecker.GetHoliday();

            Assert.Null(actual);
        }
    }
}
