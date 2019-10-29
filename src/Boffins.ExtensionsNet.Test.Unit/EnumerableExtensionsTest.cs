using FluentAssertions;
using Xunit;

namespace Boffins.ExtensionsNet.Test.Unit {
    public class EnumerableExtensionsTest 
    {
        [Fact]
        public void ShouldReturnTrueWhenEnumerable1ContainsAnyOneMemberFromEnumerable2() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            var arr2 = new[] {"d","e"};
            arr1.HasAny(arr2).Should().BeTrue();
        } 
        
        [Fact]
        public void ShouldReturnTrueWhenEnumerable1ContainsAllMembersFromEnumerable2() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            var arr2 = new[] {"d","c"};
            arr1.HasAll(arr2).Should().BeTrue();
        } 
        
        [Fact]
        public void ShouldReturnTrueWhenEnumerable1ContainsAnyOneMemberFromParamValues() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            arr1.HasAny("a","l").Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnTrueWhenEnumerable1ContainsAllMemberFromParamValues() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            arr1.HasAll("a","c").Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnFalseWhenEnumerable1DoesNotContainsAllMemberFromParamValues() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            arr1.HasAll("a","c","f").Should().BeFalse();
        } 
        
        [Fact]
        public void ShouldReturnFalseWhenEnumerable1DoesNotContainsAnyMemberFromParamValues() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            arr1.HasAny("i", "j", "f").Should().BeFalse();
        } 
        
        
        [Fact]
        public void ShouldReturnFalseWhenEnumerable1DoesNotContainsAllMemberFromEnumerable2() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            var arr2 = new[] {"a", "b", "f"};
            arr1.HasAll(arr2).Should().BeFalse();
        } 
        
        [Fact]
        public void ShouldReturnFalseWhenEnumerable1DoesNotContainsAnyMemberFromEnumerable2() 
        {
            var arr1 = new[] {"a", "b", "c", "d"};
            var arr2 = new[] {"i", "j", "f"};
            arr1.HasAny(arr2).Should().BeFalse();
        }
        
    }
}