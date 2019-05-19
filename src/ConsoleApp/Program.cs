namespace MarsRover.ConsoleApp
{
    using MarsRover.Engine;
    using MarsRover.Engine.Language;
    using MarsRover.Engine.RoverCommands;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            try
            {
                if (!TryGetPlainDimensions(out var max))
                    return;
                var plain = new Plain(max.X, max.Y);
                var rovers = new List<Rover>();

                while (true)
                {
                    if (!TryGetNextLine(out var line))
                        break;
                    if (!TryGetRoverConfig(line, out var position, out char direction))
                        return;
                    if (!TryGetCommands(out IEnumerable<char> commands))
                        return;

                    var rover = CreateRover(plain, position, direction);
                    rovers.Add(rover);

                    ExecuteCommands(rover, commands.Select(Commands.DecodeCommand));
                }

                PrintRoverPositions(rovers);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                // not all exception can be caught here and not all should be,
                // but right here I just want to gracefully exit application
                Console.WriteLine(exception.Message);
            }
        }

        private static bool TryGetPlainDimensions(
            out (int X, int Y) maxCoordinates)
        {
            return InputParser.TryGetPlainSetup(
                Console.ReadLine(),
                out maxCoordinates);
        }

        private static bool TryGetNextLine(out string line)
        {
            line = Console.ReadLine();
            return string.IsNullOrWhiteSpace(line);
        }

        private static bool TryGetRoverConfig(
            string line,
            out (int x, int y) position,
            out char direction)
        {
            return InputParser.TryGetRoverSetup(
                line,
                Directions.AllowedDirections,
                out position,
                out direction);
        }

        private static bool TryGetCommands(
            out IEnumerable<char> commands)
        {
            return InputParser.TryGetCommands(
                Console.ReadLine(),
                Commands.AllowedCommands,
                out commands);
        }

        private static Rover CreateRover(
            Plain plain,
            (int x, int y) position,
            char direction)
        {
            return new Rover(
                plain,
                position,
                Directions.DecodeDirection(direction));
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

        private static void PrintRoverPositions(
            IEnumerable<Rover> rovers)
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

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}