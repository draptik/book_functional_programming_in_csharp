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


        // Performing side effects with ForEach
        // Use 'ForEach' for side effects (not logic)
        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> ts, Action<T> action)
            => ts.Map(action.ToFunc()).ToImmutableList();

        // Map function for Option type
        // Use 'Map' for logic (no side effects!)
        public static Option<R> Map<T, R>(this Option<T> optT, Func<T, R> f) 
            => optT.Match(
                () => None,
                (t) => Some(f(t)));

        // Bind function for Option type
        public static Option<R> Bind<T, R>(this Option<T> optT, Func<T, Option<R>> f)
            => optT.Match(
                () => None,
                (t) => f(t));

        // Bind function for IEnumerable
        // This corresponds to LINQ's SelectMany.
        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, IEnumerable<R>> f)
        {
            foreach (T t in ts)
                foreach (R r in f(t))
                    yield return r;
        }

        // "Return" function for IEnumerable
        public static IEnumerable<T> List<T>(params T[] items)
            => items.ToImmutableList();

        // Where function for Option
        public static Option<T> Where<T>(this Option<T> optT, Func<T, bool> predicate)
            => optT.Match(
                () => None,
                (t) => predicate(t) ? optT : None);

        // Bind function (IEnumerable -> Option)
        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> list, Func<T, Option<R>> func)
            => list.Bind(t => func(t).AsEnumerable());

        // Bind function (Option -> IEnumerable)
        public static IEnumerable<R> Bind<T, R>(this Option<T> opt, Func<T, IEnumerable<R>> func)
            => opt.AsEnumerable().Bind(func);
    }
}
