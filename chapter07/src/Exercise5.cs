using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace Chapter07
{
    /*
        Implement `Map`, `Where`, and `Bind` for `IEnumerable` in terms of `Aggregate`.
     */
    public class Exercise5
    {
        [Fact]
        public void Map_with_Aggregate_works() 
            => Range(1, 5).Map(x => x * x).Should().Equal(1, 4, 9, 16, 25);
        
        [Fact]
        public void Where_with_Aggregate_works() 
            => Range(1, 5).Where(x => x % 2 == 0).Should().Equal(2, 4);
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> list, Func<T, R> func) 
            => list.Aggregate(new List<R>(), (acc, t) 
                => 
                {
                    acc.Add(func(t)); /* NOTE: .Add(...) returns void... */
                    return acc; /* ... that is why we have to return the list "acc" */
                });


        public static IEnumerable<T> Where<T>(this IEnumerable<T> @this, Func<T, bool> predicate) 
            => @this.Aggregate(new List<T>(), (acc, t)
                =>
                {
                    if (predicate(t))
                    {
                        acc.Add(t);
                    }
                    return acc;
                });

        // public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> @this, Func<T, R> func)
        // {
        //     return null;
        // }

    }
}
