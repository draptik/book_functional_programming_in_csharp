using FluentAssertions;
using System;
using Xunit;

namespace chapter05
{
    public class ExerciseTests
    {
        // 1. Without looking at any code or documentation (or intllisense), write the function signatures of
        // `OrderByDescending`, `Take` and `Average`, which we used to implement `AverageEarningsOfRichestQuartile`:
        /*
        static decimal AverageEarningsOfRichestQuartile(List<Person> population)
         => population
            .OrderByDescending(p => p.Earnings)
            .Take(population.Count/4)
            .Select(p => p.Earnings)
            .Average();
        */

        // OrderByDescending:   (IEnumerable<T> -> (T -> decimal)) -> IEnumerable<T>
        // Take:                (IEnumerable<T>, int) -> IEnumerable<T>
        // Average:             IEnumerable<decimal> -> decimal


        // 3. Implement a general purpose Compose function that takes two unary functions and returns the composition of the two.
        [Fact]
        public void ComposeTest()
        {
            Func<int, string> f = i => i.ToString();
            Func<string, bool> g = s => s.StartsWith("1");

            var composedFunction = g.Compose(f);
            composedFunction(1).Should().BeTrue();
            composedFunction(2).Should().BeFalse();
        }
    }

    public static class SomeExtensions
    {
        public static Func<T1, R> Compose<T1, T2, R>(this Func<T2, R> g, Func<T1, T2> f)
            => x => g(f(x));
    }

}
