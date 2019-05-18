namespace MarsRover.Tests
{
    using MarsRover.Engine;
    using System;
    using Xunit;

    public class PlainTests
    {
        [Theory]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void WhenIncorrectDimensions_ThrowsOnCreation(int x, int y)
        {
            var error = Assert.Throws<ArgumentException>(() => new Plain(x, y));
            Assert.Equal("Incorrect Plain dimensions.", error.Message);
        }

        [Theory]
        [InlineData(10, 20)]
        public void WhenCorrectDimensions_CreatedPlain(int x, int y)
        {
            Assert.NotNull(new Plain(x, y));
        }

        [Theory]
        [InlineData(10, 20, -1, 2, false)]
        [InlineData(10, 20, 1, -2, false)]
        [InlineData(10, 20, 0, 2, false)]
        [InlineData(10, 20, 1, 0, false)]
        [InlineData(10, 20, 10, 2, false)]
        [InlineData(10, 20, 1, 20, false)]
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