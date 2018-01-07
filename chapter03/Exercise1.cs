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
        public static Option<T> Parse<T>(string input)
        {
            throw new NotImplementedException("TODO");
        }
    }

    public class Exercise1
    {
        [Fact]
        public void Parsing_valid_Weekdays_returns_Some()
        {
            
            Enum.Parse<DayOfWeek>("Monday").Should().Be(Some<DayOfWeek>(DayOfWeek.Monday));
            Enum.Parse<DayOfWeek>("Tuesday").Should().Be(Some<DayOfWeek>(DayOfWeek.Tuesday));
            Enum.Parse<DayOfWeek>("Wednesday").Should().Be(Some<DayOfWeek>(DayOfWeek.Wednesday));
            Enum.Parse<DayOfWeek>("Thursday").Should().Be(Some<DayOfWeek>(DayOfWeek.Thursday));
            Enum.Parse<DayOfWeek>("Friday").Should().Be(Some<DayOfWeek>(DayOfWeek.Friday));
            Enum.Parse<DayOfWeek>("Saturday").Should().Be(Some<DayOfWeek>(DayOfWeek.Saturday));
            Enum.Parse<DayOfWeek>("Sunday").Should().Be(Some<DayOfWeek>(DayOfWeek.Sunday));
        }
        
        [Fact]
        public void Parsing_invalid_Weekdays_returns_None()
        {
            Enum.Parse<DayOfWeek>(null).Should().Be(None);
            Enum.Parse<DayOfWeek>("").Should().Be(None);
            Enum.Parse<DayOfWeek>("Invalid").Should().Be(None);
            Enum.Parse<DayOfWeek>("WednesdayX").Should().Be(None);
        }
    }
}