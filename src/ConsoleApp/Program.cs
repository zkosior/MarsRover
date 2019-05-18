namespace MarsRover.ConsoleApp
{
    using MarsRover.Engine;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            try
            {
                IoCInitialization.BuildServiceProvider().GetService(typeof(Interpretter));
                while (true)
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) return;
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception exception)
            {
                // not all exception can be caught here and not all should be,
                // but right here I just want to gracefully exit application
                Console.WriteLine(exception.Message);
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }
    }
}