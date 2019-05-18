namespace MarsRover.Engine
{
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class Rover
    {
        public Rover((int X, int Y) position, (int X, int Y) direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public (int X, int Y) Position { get; }

        public (int X, int Y) Direction { get; }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}