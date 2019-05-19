namespace MarsRover.Tests
{
    using MarsRover.Engine;
    using System;
    using Xunit;

    public class PlainTests
    {
        [Theory]
        [InlineData(10, 20)]
        public void WhenCorrectDimensions_CreatedPlain(int x, int y)
        {
            // does not throw
            Assert.NotNull(new Plain(x, y));
        }

        [Theory]
        [InlineData(10, 20, -1, 2, false)]
        [InlineData(10, 20, 2, -1, false)]
        [InlineData(10, 20, 0, 2, true)]
        [InlineData(10, 20, 1, 0, true)]
        [InlineData(10, 20, 11, 2, false)]
        [InlineData(10, 20, 1, 21, false)]
        [InlineData(10, 20, 1, 2, true)]
        public void ChecksIfPositionInsidePlain(
            int sizeX,
            int sizeY,
            int posX,
            int posY,
            bool result)
        {
            Assert.Equal(result, new Plain(sizeX, sizeY).IsPositionValid(posX, posY));
        }
    }
}