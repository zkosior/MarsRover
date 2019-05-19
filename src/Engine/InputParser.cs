namespace MarsRover.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public static class InputParser
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
            IEnumerable<char> allowedCharacters,
            out (int x, int y) position,
            out char direction)
        {
            position = default;
            direction = default;
            var elements = lineInput.Split(' ');
            if (elements.Length != 3 ||
                !int.TryParse(elements[0], out var x) ||
                !int.TryParse(elements[1], out var y) ||
                elements[2].Length != 1 ||
                lineInput.Any(p => !allowedCharacters.Contains(elements[2][0])) ||
                x < 0 ||
                y < 0) return false;
            position = (x, y);
            direction = elements[2][0];
            return true;
        }

        public static bool TryGetCommands(
            string lineInput,
            IEnumerable<char> allowedCharacters,
            out IEnumerable<char> commands)
        {
            commands = Array.Empty<char>();
            if (string.IsNullOrWhiteSpace(lineInput) ||
                lineInput.Any(p => !allowedCharacters.Contains(p))) return false;
            commands = lineInput;
            return true;
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}