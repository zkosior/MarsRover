namespace MarsRover.Engine.Language
{
    using System;
    using System.Collections.Generic;

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public static class Directions
    {
        public static IEnumerable<char> AllowedDirections =>
            new[] { 'N', 'S', 'E', 'W' };

        public static char EncodeDirection((int X, int Y) direction)
        {
            if (direction.X == 0 && direction.Y == 1) return 'N';
            if (direction.X == 0 && direction.Y == -1) return 'S';
            if (direction.X == 1 && direction.Y == 0) return 'E';
            if (direction.X == -1 && direction.Y == 0) return 'W';
            throw new InvalidOperationException();
        }

        public static (int X, int Y) DecodeDirection(char direction)
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