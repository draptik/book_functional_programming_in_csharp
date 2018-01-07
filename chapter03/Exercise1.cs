using System;
using Xunit;
using FluentAssertions;
using Functional;
using static Functional.F;

namespace chapter03
{
    public class Exercise1
    {
        public enum Weekday
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday

        }

        public static Option<Weekday> ParseWeekday(string input)
        {
            throw new NotImplementedException("TODO");
        }

        [Fact]
        public void Parsing_valid_Weekdays_returns_Some()
        {
            ParseWeekday("Monday").Should().Be(Some<Weekday>(Weekday.Monday));
            ParseWeekday("Tuesday").Should().Be(Some<Weekday>(Weekday.Tuesday));
            ParseWeekday("Wednesday").Should().Be(Some<Weekday>(Weekday.Wednesday));
            ParseWeekday("Thursday").Should().Be(Some<Weekday>(Weekday.Thursday));
            ParseWeekday("Friday").Should().Be(Some<Weekday>(Weekday.Friday));
            ParseWeekday("Saturday").Should().Be(Some<Weekday>(Weekday.Saturday));
            ParseWeekday("Sunday").Should().Be(Some<Weekday>(Weekday.Sunday));
        }
        
        [Fact]
        public void Parsing_invalid_Weekdays_returns_None()
        {
            ParseWeekday(null).Should().Be(None);
            ParseWeekday("").Should().Be(None);
            ParseWeekday("Invalid").Should().Be(None);
            ParseWeekday("WednesdayX").Should().Be(None);
        }
    }
}