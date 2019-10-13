using System.Collections.Generic;
using System.Linq;
using System.Security;
using FluentAssertions;
using Xunit;
namespace Boffins.ExtensionsNet.Test.Unit
{
    public class StringExtensionTests
    {
        [Fact]
        public void ShouldReturnTrueIfStringIsEmptyOrNull()
        {
            ((string) null).IsNullOrEmptyOrWhiteSpace().Should().BeTrue();
            "".IsNullOrEmptyOrWhiteSpace().Should().BeTrue();
        }
        
        [Fact]
        public void ShouldReturnFalseIfStringIsNotEmptyOrNull()
        {
            "test".IsNullOrEmptyOrWhiteSpace().Should().BeFalse();
        }
        
        [Fact]
        public void ShouldStripACharacterFromAString()
        {
            "test".Strip('t').Should().Be("es");
            "testeeee".Strip('e','s').Should().Be("tt");
        }
        
        [Fact]
        public void ShouldConvertToSecureString()
        {
            "test".ToSecureString().Should().BeOfType<SecureString>().And.NotBeNull();
        }
        
        [Fact]
        public void ShouldSplitAndTrimAString()
        {
             "t e st".SplitAndTrim('t').ToList().Should().BeEquivalentTo(new List<string>(){"e s"});
             "t e st".SplitAndTrim('e').ToList().Should().BeEquivalentTo(new List<string>(){"t","st"});
             "t e st".SplitAndTrim('s').ToList().Should().BeEquivalentTo(new List<string>(){"t e", "t"});
             "t e st".SplitAndTrim('s','e').ToList().Should().BeEquivalentTo(new List<string>(){"t","","t"});
             "t e st".SplitAndTrim(true,'s','e').ToList().Should().BeEquivalentTo(new List<string>(){"t","t"});
        }
    }
}