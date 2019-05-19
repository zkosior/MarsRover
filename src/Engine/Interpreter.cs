namespace MarsRover.Engine
{
    using MarsRover.Engine.Language;
    using MarsRover.Engine.RoverCommands;
    using System;
    using System.Collections.Generic;
    using System.Linq;

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public static class Interpreter
    {
        public static bool TryGetPlainSetup(
            string lineInput,
            out (int X, int Y) maxCoordinates)
        {
            maxCoordinates = default;
            var elements = lineInput.Split(' ');
            if (elements.Length != 2 ||
                !int.TryParse(elements[0], out var x) ||
                !int.TryParse(elements[1], out var y) ||
                x <= 0 ||
                y <= 0) return false;

            maxCoordinates = (x, y);
            return true;
        }

        public static bool TryGetRoverSetup(
            string lineInput,
            out (int x, int y) position,
            out (int x, int y) direction)
        {
            position = default;
            direction = default;
            var elements = lineInput.Split(' ');
            if (elements.Length != 3 ||
                !int.TryParse(elements[0], out var x) ||
                !int.TryParse(elements[1], out var y) ||
                elements[2].Length != 1 ||
                !Directions.AllowedDirections.Contains(elements[2][0]) ||
                x <= 0 ||
                y <= 0) return false;
            position = (x, y);
            direction = Directions.DecodeDirection(elements[2][0]);
            return true;
        }

        public static bool TryGetCommands(string lineInput, out IEnumerable<ICommand> commands)
        {
            commands = Array.Empty<ICommand>();
            if (lineInput.Any(p => !Commands.AllowedCommands.Contains(p))) return false;
            var decodedCommands = new List<ICommand>();
            foreach (var character in lineInput)
            {
                decodedCommands.Add(Commands.DecodeCommand(character));
            }

            commands = decodedCommands;
            return true;
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}