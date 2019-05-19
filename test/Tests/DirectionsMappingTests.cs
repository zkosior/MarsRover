namespace MarsRover.Tests
{
    using MarsRover.Engine.Language;
    using System;
    using Xunit;

    public class DirectionsMappingTests
    {
        [Fact]
        public void NotSupportedDecoding()
        {
            Assert.Throws<InvalidOperationException>(
                () => Directions.DecodeDirection('O'));
        }

        [Theory]
        [InlineData('N', 0, 1)]
        [InlineData('S', 0, -1)]
        [InlineData('E', 1, 0)]
        [InlineData('W', -1, 0)]
        public void DecodesDirections(char direction, int x, int y)
        {
            var (X, Y) = Directions.DecodeDirection(direction);
            Assert.Equal(x, X);
            Assert.Equal(y, Y);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(-1, -1)]
        [InlineData(0, 2)]
        public void NotSupportedEncodings(int x, int y)
        {
            Assert.Throws<InvalidOperationException>(
                () => Directions.EncodeDirection((x, y)));
        }

        [Theory]
        [InlineData(0, 1, 'N')]
        [InlineData(0, -1, 'S')]
        [InlineData(1, 0, 'E')]
        [InlineData(-1, 0, 'W')]
        public void EncodesDirections(int x, int y, char direction)
        {
            Assert.Equal(direction, Directions.EncodeDirection((x, y)));
        }

        [Fact]
        public void AllowedDirections()
        {
            Assert.Equal(Directions.AllowedDirections, new[] { 'N', 'S', 'E', 'W' });
        }
    }
}