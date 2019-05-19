namespace MarsRover.ConsoleApp
{
    using MarsRover.Engine;
    using MarsRover.Engine.Language;
    using MarsRover.Engine.RoverCommands;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            try
            {
                if (!InputParser.TryGetPlainSetup(
                    Console.ReadLine(),
                    out var maxCoordinates)) return;
                var plain = new Plain(maxCoordinates.X, maxCoordinates.Y);
                var rovers = new List<Rover>();

                while (true)
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) break;

                    if (!InputParser.TryGetRoverSetup(
                        line,
                        Directions.AllowedDirections,
                        out var position,
                        out var direction)) return;

                    line = Console.ReadLine();
                    if (!InputParser.TryGetCommands(
                            line,
                            Commands.AllowedCommands,
                            out var commands)) return;

                    var rover = new Rover(
                        plain,
                        position,
                        Directions.DecodeDirection(direction));
                    rovers.Add(rover);

                    ExecuteCommands(rover, commands.Select(Commands.DecodeCommand));
                }

                PrintRoverPositions(rovers);
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

        private static void ExecuteCommands(
            Rover rover,
            IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                rover.Execute(command);
            }
        }

        private static void PrintRoverPositions(IEnumerable<Rover> rovers)
        {
            foreach (var rover in rovers)
            {
                int x = rover.Position.X;
                int y = rover.Position.Y;
                char direction = Directions.EncodeDirection(rover.Direction);
                Console.WriteLine($"{x} {y} {direction}");
            }
        }
    }
}