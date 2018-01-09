using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter06
{
    // 2. Take a workflow where 2 or more functions that return an `Option`
    // are chained using `Bind`.

    // Then change the first one of the functions to return an `Either`.

    // This should cause compilation to fail. Since `Either` can be
    // converted into an `Option` as we have done in the previous exercise,
    // write extension overloads for `Bind`, so that
    // functions returning `Either` and `Option` can be chained with `Bind`,
    // yielding an `Option`.
    public class Exercise2
    {
        [Fact]
        public void Binding_Either_with_Option()
        {
            // initial version: both functions return Option
            // Func<string, Option<string>> f1Option = s => Some(s);
            // Func<string, Option<string>> f2 = s => s;
            // Func<string, Option<string>> bound1 = s => f1Option(s).Bind(f2);

            // first function returns Either
            Func<string, Either<string, string>> f1Either = s => Right(s);
            Func<string, Option<string>> f2 = s => s;
            Func<string, Option<string>> bound2 = s => f1Either(s).Bind(f2);
            bound2("foo").ToString().Should().Be("Some(foo)");
        }
    }

    public static class Ext
    {
        public static Option<RR> Bind<L, R, RR>(this Either<L, R> either, Func<R, Option<RR>> func)
            => either.Match(
                Left: _ => None,
                Right: r => func(r));

        public static Option<RR> Bind<L, R, RR>(this Option<R> option, Func<R, Either<L, RR>> func)
            => option.Match(
                None: () => None,
                Some: v => func(v).ToOption());
    }
}