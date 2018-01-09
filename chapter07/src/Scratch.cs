using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;

namespace src
{
    using Name = System.String;
    using Greeting = System.String;
    using PersonalizedGreeting = System.String;

    public class Scratch
    {
        public void Demo()
        {

            Func<Greeting, Name, PersonalizedGreeting> greet
               = (gr, name) => $"{gr}, {name}";

            Name[] names = { "Tristan", "Ivan" };

            names.Map(g => greet("Hello", g)).ForEach(Console.WriteLine);
            // prints: Hello, Tristan
            //         Hello, Ivan
        }
    }
}