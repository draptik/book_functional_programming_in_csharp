using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter06
{
    // 4. Write a function `Try` of type (() → T) → Exceptional<T> that will
    // run the given function in a `try/catch`, returning an appropriately
    // populated `Exceptional`.

    // Try : (() → T) → Exceptional<T>
    public class Exercise4
    {
        [Fact]
        public void Try_returns_Exceptional_when_successfull()
        {
            Try(() => "success").ToString().Should().Be("Success(success)");
        }

        [Fact]
        public void Try_returns_Exceptional_when_failed()
        {
            Try<string>(() => throw new Exception("Ups")).ToString()
                .Should().Be("Exception(Ups)");
        }

        static Exceptional<T> Try<T>(Func<T> func)
        {
            try
            {
                return Exceptional(func());
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
