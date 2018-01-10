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

        static Func<CountryCode, NumberType, string, PhoneNumber> PhoneNumberFactory
            = (country, type, number) => new PhoneNumber(type, country, number);

        [Fact]
        public void PhoneNumberFactory_creates_PhoneNumber_with_correct_properties()
        {
            var phoneNumber = PhoneNumberFactory((CountryCode)"de", NumberType.Home, "123");
            phoneNumber.Should().BeOfType(typeof(PhoneNumber));
            phoneNumber.NumberType.Should().Be(NumberType.Home);
            phoneNumber.Number.Should().Be("123");
            phoneNumber.CountryCode.Value.Should().Be("de");
        }

        static Func<NumberType, string, PhoneNumber> CreateUkNumber = PhoneNumberFactory.Apply((CountryCode)"uk");

        [Theory]
        [InlineData(NumberType.Home, "42", "Home, uk, 42")]
        [InlineData(NumberType.Mobile, "42", "Mobile, uk, 42")]
        [InlineData(NumberType.Office, "42", "Office, uk, 42")]
        public void CreateUkNumber_does_what_it_says(NumberType type, string number, string expected) 
            => CreateUkNumber(type, number).ToString().Should().Be(expected);

        static Func<string, PhoneNumber> CreateUkMobileNumber = CreateUkNumber.Apply(NumberType.Mobile);

        [Fact]
        public void CreateUkModuleNumber_does_what_it_says()
            => CreateUkMobileNumber("42").ToString().Should().Be("Mobile, uk, 42");
    }

    class CountryCode
    {
        public string Value { get; }
        public CountryCode(string value) => Value = value;
        public static implicit operator CountryCode(string countryCode) => new CountryCode(countryCode);
        public static implicit operator string(CountryCode countryCode) => countryCode.Value;
        public override string ToString() => Value;
    }

    public enum NumberType { Mobile, Home, Office }

    class PhoneNumber
    {
        public NumberType NumberType { get; }
        public string Number { get; }
        public CountryCode CountryCode { get; }

        public PhoneNumber(NumberType type, CountryCode countryCode, string number)
        {
            NumberType = type;
            CountryCode = countryCode;
            Number = number;
        }

        public override string ToString() => $"{NumberType.ToString()}, {CountryCode.ToString()}, {Number}";
    }
}
