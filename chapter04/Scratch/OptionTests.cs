using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using static Functional.F;

namespace Functional.Tests
{
    public class OptionTests
    {
        [Fact]
        public void NoneReturnsNone()
        {
            var result = None;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Option.None));
        }

        [Fact]
        public void SomeReturnsSome()
        {
            var result = Some("foo");
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Option<string>));
        }

        [Fact]
        public void MatchReturnsCorrectResult()
        {
            // sample function
            string greet(Option<string> greetee)
                => greetee.Match(
                    None: () => "Sorry, who?",
                    Some: (name) => $"Hello, {name}");

            greet(None).Should().Be("Sorry, who?");
            greet(Some("John")).Should().Be("Hello, John");
        }
    }
}