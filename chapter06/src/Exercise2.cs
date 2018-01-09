using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter06
{
    // 2. Take a workflow where 2 or more functions that return an `Option`
    // are chained using `Bind`.

    // Then change the first one of the functions to return an `Either`.

    // This should cause compilation to fail. Since `Either` can be
    // converted into an `Option` as we have done in the previous exercise,
    // write extension overloads for `Bind`, so that
    // functions returning `Either` and `Option` can be chained with `Bind`,
    // yielding an `Option`.
    public class Exercise2
    {

    }
}