using ConfusedExercise.SystemUnderTest.Models;
using System;

namespace ConfusedExercise.SystemUnderTest.TestData
{
    internal static class Computers
    {
        internal static Computer UniqueComputer
            => new Computer($"Amiga {Guid.NewGuid()}", "1998-01-01", "2008-12-31", "Commodore International");
    }
}
