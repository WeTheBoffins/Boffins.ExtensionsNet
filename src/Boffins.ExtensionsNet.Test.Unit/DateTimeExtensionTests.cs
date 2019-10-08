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
        public void ShouldReturnFalseForMinValueDate1() 
        {
            DateTime? dateTime = null;
            dateTime.IsNotMinDate().Should().BeFalse();
        }
        
        
    }
}