using System;

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
            {
                throw new ArgumentNullException();
            }

            Value = value;
        }
    }
}