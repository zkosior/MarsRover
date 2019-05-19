namespace MarsRover.Engine
{
    using System.Diagnostics;

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class Plain : IPlain
    {
        private readonly int maxX;
        private readonly int maxY;

        public Plain(int maxX, int maxY)
        {
            Debug.Assert(maxX > 0 && maxY > 0, "Incorrect Plain maxCoordinates.");
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public bool IsPositionValid(int x, int y)
        {
            return x >= 0 &&
                   x <= this.maxX &&
                   y >= 0 &&
                   y <= this.maxY;
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}