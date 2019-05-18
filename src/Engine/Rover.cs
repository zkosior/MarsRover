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

        public (int X, int Y) Position { get; private set; }

        public (int X, int Y) Direction { get; private set; }

        public void Move()
        {
            this.Position =
                (this.Position.X + this.Direction.X,
                this.Position.Y + this.Direction.Y);
        }

        public void RotateLeft()
        {
            this.Direction = (this.Direction.Y * -1, this.Direction.X);
        }

        public void RotateRight()
        {
            this.Direction = (this.Direction.Y, this.Direction.X * -1);
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}