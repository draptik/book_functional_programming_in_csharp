using System;
using FluentAssertions;
using Xunit;

namespace Scratch
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            1.Should().Be(1);
        }
    }
}
