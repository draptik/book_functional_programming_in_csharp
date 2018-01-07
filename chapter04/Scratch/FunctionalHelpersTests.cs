using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Scratch
{
    public class FunctionalHelpersTests
    {
        [Fact]
        public void NoneReturnsNone()
        {
            var result = FunctionalHelpers.None;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Option.None));
        }

        [Fact]
        public void SomeReturnsSome()
        {
            var result = FunctionalHelpers.Some("foo");
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Option.Some<string>));
            result.Value.Should().Be("foo");
        }


        [Fact]
        public void MapSimpleTest()
        {
            Func<int, int> times3 = x => x * 3;
            
            Enumerable.Range(1, 3).MapSimple(times3)
                .Should().Equal(3, 6, 9);
        }

        [Fact]
        public void MapTest()
        {
            Func<int, int> times3 = x => x * 3;
            
            Enumerable.Range(1, 3).Map(times3)
                .Should().Equal(3, 6, 9);
        }
    }
}
