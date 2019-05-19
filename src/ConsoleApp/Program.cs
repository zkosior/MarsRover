namespace MarsRover.ConsoleApp
{
    using MarsRover.Engine;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            try
            {
                if (!Interpreter.TryGetPlainSetup(
                    Console.ReadLine(),
                    out var maxCoordinates)) return;
                var plain = new Plain(maxCoordinates.X, maxCoordinates.Y);
                var rovers = new List<Rover>();

                while (true)
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) break;
                    if (!Interpreter.TryGetRoverSetup(line, out var position, out var direction)) return;
                    if (!Interpreter.TryGetCommands(Console.ReadLine(), out var commands)) return;
                    var rover = new Rover(plain, position, direction);
                    rovers.Add(rover);
                    foreach (var command in commands)
                    {
                        command.Execute(rover);
                    }
                }

                foreach (var rover in rovers)
                {
                    Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {Interpreter.EncodeDirection(rover.Direction)}");
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