namespace MarsRover.Engine
{
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
                !new[] { 'N', 'S', 'E', 'W' }.Contains(elements[2][0]) ||
                x <= 0 ||
                y <= 0) return false;
            position = (x, y);
            direction = DecodeDirection(elements[2][0]);
            return true;
        }

        public static bool TryGetCommands(string lineInput, out IEnumerable<ICommand> commands)
        {
            commands = Array.Empty<ICommand>();
            if (lineInput.Any(p => !new[] { 'M', 'L', 'R' }.Contains(p))) return false;
            var decodedCommands = new List<ICommand>();
            foreach (var character in lineInput)
            {
                decodedCommands.Add(DecodeCommand(character));
            }

            commands = decodedCommands;
            return true;
        }

        public static char EncodeDirection((int X, int Y) direction)
        {
            if (direction.X == 0 && direction.Y == 1) return 'N';
            if (direction.X == 0 && direction.Y == -1) return 'S';
            if (direction.X == 1 && direction.Y == 0) return 'E';
            if (direction.X == -1 && direction.Y == 0) return 'W';
            throw new InvalidOperationException();
        }

        private static ICommand DecodeCommand(char command)
        {
            switch (command)
            {
                case 'M':
                    return new Move();

                case 'L':
                    return new RotateLeft();

                case 'R':
                    return new RotateRight();

                default:
                    throw new InvalidOperationException();
            }
        }

        private static (int x, int y) DecodeDirection(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return (0, 1);

                case 'S':
                    return (0, -1);

                case 'E':
                    return (1, 0);

                case 'W':
                    return (-1, 0);

                default:
                    throw new InvalidOperationException();
            }
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}