namespace MarsRover.Engine.Language
{
    using MarsRover.Engine.RoverCommands;
    using System;
    using System.Collections.Generic;

    public static class Commands
    {
        public static IEnumerable<char> AllowedCommands =>
            new[] { 'M', 'L', 'R' };

        public static ICommand DecodeCommand(char command)
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
    }
}