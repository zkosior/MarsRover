namespace MarsRover.Engine
{
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class Rover
    {
        private readonly IPlain plain;

        public Rover(
            IPlain plain,
            (int X, int Y) position,
            (int X, int Y) direction)
        {
            if (!plain.IsPositionValid(position.X, position.Y))
                throw new System.ArgumentException("Position not on Plain.");

            this.plain = plain;
            this.Position = position;
            this.Direction = direction;
        }

        public (int X, int Y) Position { get; private set; }

        public (int X, int Y) Direction { get; private set; }

        public void Move()
        {
            var newX = this.Position.X + this.Direction.X;
            var newY = this.Position.Y + this.Direction.Y;
            if (!this.plain.IsPositionValid(newX, newY))
                throw new System.ArgumentException("Final position outside Plain.");
            this.Position = (newX, newY);
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