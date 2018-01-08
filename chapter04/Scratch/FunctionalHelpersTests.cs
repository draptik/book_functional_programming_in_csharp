using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using Functional;
using static Functional.F;
using System.Collections.Generic;

namespace Scratch
{
    public class FunctionalHelpersTests
    {
        [Fact]
        public void MapSimpleTest()
        {
            Func<int, int> times3 = x => x * 3;
            
            Enumerable.Range(1, 3).MapSimple(times3)
                .Should().Equal(3, 6, 9);
        }

        [Fact]
        public void MapTest()
        {
            Func<int, int> times3 = x => x * 3;
            
            Enumerable.Range(1, 3).Map(times3)
                .Should().Equal(3, 6, 9);
        }

        [Fact]
        public void OptionMapTest()
        {
            Func<string, string> greet = name => $"Hello, {name}";

            Option<string> _ = None;
            Option<string> optJohn = Some("John");

            _.Map(greet).IsSome().Should().BeFalse();
            optJohn.Map(greet).IsSome().Should().BeTrue();
        }

        [Fact]
        public void ForEachTest()
        {
            Action<int> Write = x => Console.Write(x.ToString());
            Enumerable.Range(1, 5).ForEach<int>(Write);
        }

        [Fact]
        public void BindForOptionTest()
        {
            Func<string, Option<Age>> parseAge = s => Int.Parse(s).Bind(Age.Of);

            parseAge("26").IsSome().Should().BeTrue();
            parseAge("invalid").IsSome().Should().BeFalse();
            parseAge("180").IsSome().Should().BeFalse();
        }

        [Fact]
        public void BindForIEnumerableTest()
        {
            var neighbors = new[]
            {
                new { Name = "John", Pets = new Pet[] {"Fluffy", "Thor"} },
                new { Name = "Tim", Pets = new Pet[] {} },
                new { Name = "Carl", Pets = new Pet[] {"Sybil"} },
            };

            IEnumerable<IEnumerable<Pet>> nested = neighbors.Map(n => n.Pets);
            // => [["Fluffy", "Thor"], [], ["Sybil"]]

            IEnumerable<Pet> flat = neighbors.Bind(n => n.Pets);
            // => ["Fluffy", "Thor", "Sybil"]
        }
        
        internal class Pet
        {
            private readonly string name;

            private Pet(string name)
            {
                this.name = name;
            }

            public static implicit operator Pet(string name)
                => new Pet(name);
        }

        public struct Age
        {
            private int Value { get; }
            private Age(int value)
            {
                if (!IsValid(value))
                    throw new ArgumentException($"{value} is not a valid age");

                Value = value;
            }

            private static bool IsValid(int age)
                => 0 <= age && age < 120;

            public static Option<Age> Of(int age)
                => IsValid(age) ? Some(new Age(age)) : None;

            public static bool operator <(Age l, Age r) => l.Value < r.Value;
            public static bool operator >(Age l, Age r) => l.Value > r.Value;

            public static bool operator <(Age l, int r) => l < new Age(r);
            public static bool operator >(Age l, int r) => l > new Age(r);

            public override string ToString() => Value.ToString();
        }

        public static class Int
        {
            public static Option<int> Parse(string s)
            {
                int result;
                return int.TryParse(s, out result) ? Some(result) : None;
            }
        }
    }
}
