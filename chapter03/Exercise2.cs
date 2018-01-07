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
    public static class FunctionalExtensions
    {
        public static Option<T> Lookup<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return Some(item);
                }
            }
            return None;
        }
    }

    // Write a Lookup function that will take an IEnumerable and a predicate, and
    // return the first element in the IEnumerable that matches the 
    // predicate, or None if no matching element is found. 
    // Write its signature in arrow notation.
    public class Exercise2
    {
        bool isOdd(int i) => i % 2 == 1;

        [Fact]
        public void Empty_list_returns_None()
        {
            new List<int>()
                .Lookup(isOdd)
                .IsSome().Should().BeFalse();
        }

        [Fact]
        public void List_with_no_odd_numbers_returns_None()
        {
            new List<int>{ 0, 2, 4 }
                .Lookup(isOdd)
                .IsSome().Should().BeFalse();
        }

        [Fact]
        public void List_with_odd_number_included_returns_first_occurrence_of_odd_number()
        {
            new List<int>{ 0, 1, 4 }
                .Lookup(isOdd)
                .IsSome().Should().BeTrue();
        }
    }
}
