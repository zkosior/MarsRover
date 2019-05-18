namespace MarsRover.Engine
{
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class Plain : IPlain
    {
        private readonly (int X, int Y) dimensions;

        public Plain(int x, int y)
        {
            if (x <= 0 || y <= 0)
                throw new System.ArgumentException("Incorrect Plain dimensions.");
            this.dimensions = (x, y);
        }

        public bool IsPositionValid(int x, int y)
        {
            return x > 0 &&
                   x < this.dimensions.X &&
                   y > 0 &&
                   y < this.dimensions.Y;
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}