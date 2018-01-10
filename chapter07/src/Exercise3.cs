using LaYumba.Functional;
using static LaYumba.Functional.F;

using System;
using FluentAssertions;
using Xunit;

namespace Chapter07
{
    /*
        Functions everywhere. You may still have a feeling that objects are ultimately more powerful than functions. Surely a logger object should expose methods for related operations such as Debug, Info, and Error? To see that this is not necessarily so, challenge yourself to write a very simple logging mechanism (logging to the console is fine) that doesn’t require any classes or structs. You should still be able to inject a Log value into a consumer class or function, exposing the operations Debug, Info, and Error, like so:

            void ConsumeLog(Log log)
                => log.Info("look! no classes!");
     */
    public class Exercise3
    {
        // Use string return type for easier Unit Testing
        // string ConsumeLog(Log log) => log.Info("look! no classes!");

        // Func<>
    }
}
