using System;
using Unit = System.ValueTuple;

namespace Functional
{
    using System.Collections.Generic;
    using static F;
    
    public static partial class F
    {
        public static Option.None None => Option.None.Default;
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);

        public static Unit Unit() => default(Unit);
    }


    public struct Option<T>
    {
        readonly bool isSome;
        readonly T value;

        private Option(T value)
        {
            this.isSome = true;
            this.value = value;
        }
        
        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        // "Return" function. This function "elevates" T to Option<T>.
        public static implicit operator Option<T>(T value) => value == null ? None : Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some) => isSome ? Some(value) : None();

        public bool IsSome() => isSome;

        public IEnumerable<T> AsEnumerable()
        {
            if (isSome) yield return value;
        }
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new None();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), 
                        "Cannot wrap a null value in a 'Some'; use 'None' instead");
                Value = value;
            }
        }
    }
}