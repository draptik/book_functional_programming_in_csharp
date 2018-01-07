using System;
using Xunit;
using FluentAssertions;
using Functional;
using static Functional.F;

namespace chapter03
{
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday

    }

    public static class Enum
    {
        public static Option<T> Parse<T>(this string input) where T : struct
            => System.Enum.TryParse(input, out T t) ? Some(t) : None; 
    }
 
    public class Exercise1
    {
        [Fact]
        public void Parsing_string_to_enum_should_always_return_Option_DayOfWeek()
        {
            Enum.Parse<DayOfWeek>("invalid").Should().BeOfType(typeof(Option<DayOfWeek>));
            Enum.Parse<DayOfWeek>("Monday").Should().BeOfType(typeof(Option<DayOfWeek>));
        }

        [Fact]
        public void Parsing_valid_Weekdays_returns_Some_weekday()
        {
            Enum.Parse<DayOfWeek>("Monday").Should().Be(Some<DayOfWeek>(DayOfWeek.Monday));
            Enum.Parse<DayOfWeek>("Tuesday").Should().Be(Some<DayOfWeek>(DayOfWeek.Tuesday));
            Enum.Parse<DayOfWeek>("Wednesday").Should().Be(Some<DayOfWeek>(DayOfWeek.Wednesday));
            Enum.Parse<DayOfWeek>("Thursday").Should().Be(Some<DayOfWeek>(DayOfWeek.Thursday));
            Enum.Parse<DayOfWeek>("Friday").Should().Be(Some<DayOfWeek>(DayOfWeek.Friday));
            Enum.Parse<DayOfWeek>("Saturday").Should().Be(Some<DayOfWeek>(DayOfWeek.Saturday));
            Enum.Parse<DayOfWeek>("Sunday").Should().Be(Some<DayOfWeek>(DayOfWeek.Sunday));
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalid")]
        public void Parsing_invalid_Weekdays_returns_None(string input)
        {
            Enum.Parse<DayOfWeek>(input)
                .Match(
                    None: () => "invalid",
                    Some: (value) => "valid"
                )
                .Should().Be("invalid");
        }
    }
}