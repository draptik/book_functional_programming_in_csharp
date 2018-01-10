using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace src
{
    public class SelectManyPlaygroundTests
    {
        [Fact]
        public void TestName()
        {
            string[] fruits = { "Grape", "Orange", "Apple" };
            int[] amounts = { 1, 2, 3 };

            var result = fruits.SelectMany(f => amounts, (f, a) => new { Fruit = f, Amount = a });
            var x = 1;
        }

        [Fact]
        public void AnotherTest()
        {
            var people = new List<Person>
            {
                new Person("a") { PhoneNumbers = new List<PhoneNumber> { new PhoneNumber("1"), new PhoneNumber("2"), new PhoneNumber("3")}},
                new Person("b") { PhoneNumbers = new List<PhoneNumber> { new PhoneNumber("4"), new PhoneNumber("5"), new PhoneNumber("5")}}
            };

            // Using `Select`: Not quite what we want...
            IEnumerable<IEnumerable<PhoneNumber>> phoneList = people.Select(p => p.PhoneNumbers);

            // Using `SelectMany` to flatten to a list of phone numbers:
            var result = people.SelectMany(p => p.PhoneNumbers);
            result.Count().Should().Be(6);
            result.First().Number.Should().Be("1");
        }
    }

    public class PhoneNumber
    {
        public string Number { get; set; }
        public PhoneNumber(string number) => Number = number;
    }

    class Person
    {
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }
        public Person(string name) => Name = name;
    }
}