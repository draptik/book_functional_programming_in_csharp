using System;
using System.Collections.Generic;
using System.Linq;
using Unit = System.ValueTuple;

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
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f) 
            => ts.Select(f);
    }
}
