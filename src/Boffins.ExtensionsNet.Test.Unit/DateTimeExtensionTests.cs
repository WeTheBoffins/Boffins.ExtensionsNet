using System;
using FluentAssertions;
using Xunit;

namespace Boffins.ExtensionsNet.Test.Unit 
{
    public class DateTimeExtensionTests 
    {
        [Fact]
        public void ShouldReturnTrueForNonMinValueDate() 
        {
            DateTime? dateTime = DateTime.Today;
            dateTime.IsNotMinDate().Should().BeTrue();
        }
        
        [Fact]
        public void ShouldReturnFalseForMinValueDate() 
        {
            DateTime? dateTime = DateTime.MinValue;
            dateTime.IsNotMinDate().Should().BeFalse();
        }
        
        [Fact]
        public void ShouldReturnFalseForNullDate() 
        {
            DateTime? dateTime = null;
            dateTime.IsNotMinDate().Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnFirstDayOfTheMonth()
        {
            var date = new DateTime(2019,10,7);
            date.FirstDayOfTheMonth().Should().Be(new DateTime(2019,10,1));
        }

        [Fact]
        public void ShouldReturnLastDayOfTheMonth()
        {
            var date = new DateTime(2019,10,7);
            date.LastDayOfMonth().Should().Be(new DateTime(2019,10,31));
        }
        
        [Fact]
        public void ShouldReturnFirstDayOfTheNextMonth()
        {
            var date = new DateTime(2019,10,7);
            date.FirstDayOfNextMonth().Should().Be(new DateTime(2019,11,1));
        }
        
        [Fact]
        public void ShouldReturnTrueIfTodayIsLeapDay()
        {
            var date = new DateTime(2016,2,29);
            date.IsLeapDay().Should().BeTrue();
        }
        
        [Fact]
        public void ShouldReturnFalseIfTodayIsLeapDay()
        {
            var date = new DateTime(2016,3,29);
            date.IsLeapDay().Should().BeFalse();
        }
        
        [Fact]
        public void ShouldReturnTrueIfCurrentYearIsLeapYear()
        {
            var date = new DateTime(2016,3,29);
            date.IsLeapYear().Should().BeTrue();
        }
        
        [Fact]
        public void ShouldReturnFalseIfCurrentYearIsNotLeapYear()
        {
            var date = new DateTime(2017,3,29);
            date.IsLeapYear().Should().BeFalse();
        }
        
        [Fact]
        public void ShouldReturnNumberOfDaysBetweenTwoDates()
        {
            var date1 = new DateTime(2017,3,1);
            var date2 = date1.AddDays(5);
            date1.DaysBetweenDates(date2).Should().Be(6);
        }
        
        [Fact]
        public void ShouldReturnTrueIfDayIsWeekend()
        {
            var date1 = new DateTime(2019,10,5);
            var date2 = date1.AddDays(1);
            var date3 = date2.AddDays(1);
            
            date1.IsWeekend().Should().BeTrue();
            date2.IsWeekend().Should().BeTrue();
            date3.IsWeekend().Should().BeFalse();
        }
        
        [Fact]
        public void ShouldReturnMonthsBetweenTwoDates()
        {
            var date1 = new DateTime(2017,3,1);
            var date2 = date1.AddMonths(5);
            
            var months = date1.MonthsBetweenDates(date2);

            months.Should().HaveCount(6).
                And.BeInAscendingOrder().
                And.OnlyHaveUniqueItems().
                And.StartWith(new DateTime(2017, 3, 1)).
                And.EndWith(new DateTime(2017, 8, 1));

        }

    }
}