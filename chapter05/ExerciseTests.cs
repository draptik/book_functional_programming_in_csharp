using FluentAssertions;
using System;
using Xunit;

namespace chapter05
{
    public class ExerciseTests
    {
        [Fact]
        public void Test1()
        {
            "1".Should().Be("1");
        }
    }
}
