namespace MarsRover.Engine
{
    using System.Diagnostics;

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class Plain : IPlain
    {
        private readonly (int X, int Y) maxCoordinates;

        public Plain(int maxX, int maxY)
        {
            Debug.Assert(maxX > 0 && maxY > 0, "Incorrect Plain maxCoordinates.");
            this.maxCoordinates = (maxX, maxY);
        }

        public bool IsPositionValid(int x, int y)
        {
            return x >= 0 &&
                   x <= this.maxCoordinates.X &&
                   y >= 0 &&
                   y <= this.maxCoordinates.Y;
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}