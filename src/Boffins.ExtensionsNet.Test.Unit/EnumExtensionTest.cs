using System.ComponentModel;
using System.Linq;
using FluentAssertions;
using Xunit;
using static Boffins.ExtensionsNet.EnumExtensions;

namespace Boffins.ExtensionsNet.Test.Unit
{
    public class EnumExtensionTest
    {
        enum TestEnum
        {
            None = 0,
            [Description("Fact Enum 1")] 
            TestEnum1 = 1,
            TestEnum2 = 2,
        }

        [Fact]
        public void ShouldReturnDictionaryForAnEnum1()
        {
            var dictionary = ToDictionary<TestEnum>();

            dictionary.Count().Should().Be(3);
            dictionary.Last().Value.Should().Be("TestEnum2");
        }

        [Fact]
        public void ShouldReturnDictionaryForAnEnum()
        {
            var myEnum = TestEnum.TestEnum1;
            var dictionary = myEnum.ToDictionary();

            dictionary.Count().Should().Be(3);
            dictionary.Last().Value.Should().Be("TestEnum2");
        }

        [Fact]
        public void ShouldReturnEnumFromString()
        {
            "TestEnum1".ToEnum<TestEnum>()
                .Should().Be(TestEnum.TestEnum1);
        }

        [Fact]
        public void ShouldReturnNoneWhenStringIsNotPresentInEnum()
        {
            var enumType = "TestEnum4".ToEnum<TestEnum>();
            enumType.Should().Be(TestEnum.None);
        }

        [Fact]
        public void ShouldGetDescriptionOfEnum()
        {
            var desc = TestEnum.TestEnum1.GetDescription();
            desc.Should().Be("Fact Enum 1");
        }

        [Fact]
        public void ShouldReturnEnumNameIfDescriptionOfEnumIsNotApplied()
        {
            var desc = TestEnum.TestEnum2.GetDescription();
            desc.Should().Be(TestEnum.TestEnum2.ToString());
        }
    }
}