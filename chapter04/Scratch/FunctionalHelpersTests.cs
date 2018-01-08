using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using Functional;
using static Functional.F;

namespace Scratch
{
    public class FunctionalHelpersTests
    {
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

        [Fact]
        public void OptionMapTest()
        {
            Func<string, string> greet = name => $"Hello, {name}";

            Option<string> _ = None;
            Option<string> optJohn = Some("John");

            _.Map(greet).IsSome().Should().BeFalse();
            optJohn.Map(greet).IsSome().Should().BeTrue();
        }

        [Fact]
        public void ForEachTest()
        {
            Action<int> Write = x => Console.Write(x.ToString());
            Enumerable.Range(1, 5).ForEach<int>(Write);
        }
    }
}
