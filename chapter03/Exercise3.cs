using System;
using Xunit;
using FluentAssertions;
using Functional;
using static Functional.F;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace chapter03
{
    public class Exercise3
    {
        /*
            Write a type Email that wraps an underlying string, enforcing that it's in a valid format. Ensure that you include the following:
                A smart constructor
                Implicit conversion to string, so that it can easily be used with the typical API for sending emails
         */

        // public struct Email
        // {
        //     private string Value { get; }

        //     private Email(string value)
        //     {
        //         if (!IsValid(value))
        //         {
        //             throw new ArgumentException("${value} is not a valid email address");
        //         }

        //         Value = value;
        //     }

        //     private static bool IsValid(string value)
        //         => 
        // }

        [Fact]
        public void Email_cannot_be_created_with_an_invalid_string()
        {
        }
    }
}