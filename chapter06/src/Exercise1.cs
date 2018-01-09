using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter06
{
    public static class SomeExtensions
    {
        public static Option<R> ToOption<L, R>(this Either<L, R> either)
            => either.Match(
                Left: (l) => None,
                Right: (r) => Some(r));

        public static Either<L, R> ToEither<L, R>(this Option<R> option, Func<L> failure)
            => option.Match<Either<L, R>>(
                None: () => failure(),
                Some: (content) => Right(content));
    }

    // 1. Write a `ToOption` extension method to convert an `Either` into an
    // `Option`. Then write a `ToEither` method to convert an `Option` into an
    // `Either`, with a suitable parameter that can be invoked to obtain the
    // appropriate `Left` value, if the `Option` is `None`. (Tip: start by writing
    // the function signatures in arrow notation)
    public class Exercise1
    {
        [Fact]
        public void ToOption_converts_successfull_Either_to_Option()
        {
            Either<string, string> either = Right("success");
            either.ToOption().ToString().Should().Be("Some(success)");
        }

        [Fact]
        public void ToOption_converts_failing_Either_to_Option()
        {
            Either<string, string> either = Left("failure");
            either.ToOption().ToString().Should().Be("None");
        }

        [Fact]
        public void ToEither_converts_successfull_Option_to_Either()
        {
            Option<string> option = Some("success");
            option.ToEither(() => "failure").ToString().Should().Be("Right(success)");
        }

        [Fact]
        public void ToEither_converts_failing_Option_to_Either()
        {
            Option<string> option = None;
            option.ToEither(() => "failure").ToString().Should().Be("Left(failure)");
        }
    }
}
