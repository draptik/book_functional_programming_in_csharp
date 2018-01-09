using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter06
{
    // 3. Write a function `Safely` of type ((() → R), (Exception → L)) → Either<L, R> that will
    // run the given function in a `try/catch`, returning an appropriately
    // populated `Either`.
    public class Exercise3
    {
        [Fact]
        public void Safely_returns_Either_with_success()
        {
            Func<string> someFunction = () => "success";
            Func<Exception, string> errorFunction = ex => ex.Message;
            var result = Safely(someFunction, errorFunction);
            result.ToString().Should().Be("Right(success)");
        }
        
        [Fact]
        public void Safely_returns_Either_with_failure()
        {
            Func<string> someFunction = () => throw new Exception("Ups");
            Func<Exception, string> errorFunction = ex => ex.Message;
            var result = Safely(someFunction, errorFunction);
            result.ToString().Should().Be("Left(Ups)");
        }

        // ((() → R), (Exception → L)) → Either<L, R>
        static Either<L, R> Safely<L, R>(Func<R> func, Func<Exception, L> left)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                return left(ex);
            }
        }
    }
}
