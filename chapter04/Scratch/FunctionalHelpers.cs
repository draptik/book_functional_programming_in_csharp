using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Functional;
using Unit = System.ValueTuple;
using static Functional.F;

namespace Scratch
{
    public static class FunctionalHelpers
    {
        // Simple implementation of LINQ's 'Select'
        public static IEnumerable<R> MapSimple<T, R>(this IEnumerable<T> ts, Func<T, R> f)
        {
            foreach (var t in ts)
            {  
                yield return f(t);
            }
        }

        // Calling LINQ's Select. Map is the more common name in FP...
        // Signature:
        //      (IEnumerable<T>, (T -> R)) -> IEnumerable<R>
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f) 
            => ts.Select(f);

        // Map function for Option type
        public static Option<R> Map<T, R>(this Option<T> optT, Func<T, R> f) 
            => optT.Match(
                () => None,
                (t) => Some(f(t)));

        // Performing side effects with ForEach
        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> ts, Action<T> action)
            => ts.Map(action.ToFunc()).ToImmutableList();
    }
}
