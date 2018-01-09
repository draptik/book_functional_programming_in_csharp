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
    }
}
