using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter07
{
    /*
        Ternary functions:
        
        1. Define a PhoneNumber class with three fields: number type (home, mobile, ...), country code (‘it’, ‘uk’, ...), and number. CountryCode should be a custom type with implicit conversion to and from string.
        
        2. Define a ternary function that creates a new number, given values for these fields. What’s the signature of your factory function?
        
        3. Use partial application to create a binary function that creates a UK number, and then again to create a unary function that creates a UK mobile.
     */
    public class Exercise2
    {
        [Fact]
        public void Implicit_conversion_from_CountryCode_to_string()
        {
            var countryCode = new CountryCode("de");
            string result = countryCode;
            result.Should().Be("de");
        }

        [Fact]
        public void Implicit_conversion_from_string_to_CountryCode()
        {
            CountryCode result = "de";
            result.Should().BeOfType(typeof(CountryCode));
        }
    }

    class CountryCode
    {
        public string Value { get; }

        public CountryCode(string value) => Value = value;

        public static implicit operator CountryCode(string countryCode) => new CountryCode(countryCode);
        public static implicit operator string(CountryCode countryCode) => countryCode.Value;
    }

    class PhoneNumber
    {
        public string NumberType { get; set; }
        public string Value { get; set; }
        public CountryCode CountryCode { get; set; }
    }
}
