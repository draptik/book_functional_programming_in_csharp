using System;
using Xunit;
using FluentAssertions;

namespace chapter03
{
    public class UnitTest1
    {
        enum Risk { Low, Medium, High }

        Risk CalculateRiskProfile(int age) 
        {
            return (age < 60) ? Risk.Low : Risk.Medium;
        }

        [Fact]
        public void Test1()
        {
            CalculateRiskProfile(1).Should().Be(Risk.Low);
            CalculateRiskProfile(60).Should().Be(Risk.Medium);
        }
    }
}
