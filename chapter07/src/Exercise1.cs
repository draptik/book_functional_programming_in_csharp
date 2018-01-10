using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter07
{
    /*
        Partial application with a binary arithmetic function:
        
        1. Write a function, Remainder, that calculates the remainder of integer division (and works for negative input values!). Notice how the expected order of parameters isn’t the one that’s most likely to be required by partial application (you’re more likely to partially apply the divisor).
        
        2. Write an ApplyR function that gives the rightmost parameter to a given binary function. (Try to do so without looking at the implementation for Apply.) Write the signature of ApplyR in arrow notation, both in curried and non-curried forms.
        
        3. Use ApplyR to create a function that returns the remainder of dividing any number by 5.
        
        4. Write an overload of ApplyR that gives the rightmost argument to a ternary function.
     */
    public class Exercise1
    {
        Func<int, int, int> Remainder = (dividend, divisor) => dividend % divisor;

        [Theory]
        [InlineData(4, 2, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(-5, 3, -2)]
        public void Remainder_is_calculated_correctly(int dividend, int divisor, int expected) 
            => Remainder(dividend, divisor).Should().Be(expected);

        [Fact]
        public void ApplyR_returns_rightmost_parameter()
        {
            // TODO: Revisit this later...
            Func<int, string, bool> fun = (i, s) => true;
            fun.ApplyR("someString").Should().BeOfType(typeof(Func<int, bool>));
        }

        [Theory]
        [InlineData(10, 0)]
        [InlineData(11, 1)]
        [InlineData(14, 4)]
        public void Returns_remainder_of_division_by_5(int dividend, int expected)
        {
            var remainderBy5 = Remainder.ApplyR(5);
            remainderBy5(dividend).Should().Be(expected);
        }

        [Fact]
        public void ApplyR_returns_rightmost_parameter_to_ternary_function()
        {
            // TODO: Revisit this later...
            Func<int, string, double, bool> fun = (i, s, d) => true;
            fun.ApplyR(1.0).Should().BeOfType(typeof(Func<int, string, bool>));
        }
    }

    public static class Extensions
    {
        // (((T1, T2) -> R), T2) -> T1 -> R
        // (T1 -> T2 -> R) -> T2 -> T1 -> R (curried) 
        public static Func<T1, R> ApplyR<T1, T2, R>(this Func<T1, T2, R> func, T2 t2)
            => t1 => func(t1, t2);

        public static Func<T1, T2, R> ApplyR<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T3 t3)
            => (t1, t2) => func(t1, t2, t3);
    }
}
