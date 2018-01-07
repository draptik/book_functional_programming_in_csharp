using Xunit;
using FluentAssertions;
using Functional;
using static Functional.F;
using System.ComponentModel.DataAnnotations;

namespace chapter03
{
    /*
        Write a type Email that wraps an underlying string, enforcing that it's in a valid format. 
        Ensure that you include the following:
            - A smart constructor
            - Implicit conversion to string, so that it can easily be used with the typical API for sending emails
    */
    public class Exercise3
    {
        public struct Email
        {
            private string Value { get; }

            private Email(string value) => Value = value;

            // Smart ctor
            public static Option<Email> Create(string s)
                => IsValid(s)
                    ? Some(new Email(s))
                    : None;

            // Use the built-in email validation (instead of some Regex): 
            //      EmailAddressAttribute().IsValid(...)
            // Yes, this also works with .NET Core: Just include the following:
            //      using System.ComponentModel.DataAnnotations;
            private static bool IsValid(string value)
                => new EmailAddressAttribute().IsValid(value);
        }

        [Theory]
        [InlineData("invalid")]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("a.b")]
        public void Email_cannot_be_created_with_an_invalid_string(string input)
        {
            Email.Create(input)
                .IsSome()
                .Should().BeFalse();
        }

        [Theory]
        [InlineData("foo@bar.com")]
        [InlineData("a@b.c")]
        [InlineData("a@b")]
        public void Valid_input_creates_Email(string input)
        {
            Email.Create(input)
                .IsSome()
                .Should().BeTrue();
        }
    }
}