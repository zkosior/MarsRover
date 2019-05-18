namespace MarsRover.Tests
{
    using AutoFixture.Xunit2;
    using MarsRover.Engine;
    using NSubstitute;
    using System;
    using Xunit;

#pragma warning disable SA1009 // Closing parenthesis must be spaced correctly

    [Trait("TestCategory", "Unit")]
    public class RoverTests
    {
        private readonly IPlain plain = Substitute.For<IPlain>();

        [Theory]
        [AutoData]
        public void WhenRoverCreated_HasPositionOnPlainAndDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
            var rover = new Rover(this.plain, (posX, posY), (dirX, dirY));
            Assert.Equal(posX, rover.Position.X);
            Assert.Equal(posY, rover.Position.Y);
            Assert.Equal(dirX, rover.Direction.X);
            Assert.Equal(dirY, rover.Direction.Y);
        }

        [Theory]
        [AutoData]
        public void WhenRoverCreatedWithInvalidPositionOnPlain_Throws(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(false);
            var error = Assert.Throws<ArgumentException>(
                () => new Rover(this.plain, (posX, posY), (dirX, dirY)));
            Assert.Equal("Position not on Plain.", error.Message);
        }

        [Theory]
        [AutoData]
        public void WhenRoverMoved_HasNewPositionOnPlainAndSameDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(true, true);
            var rover = new Rover(this.plain, (posX, posY), (dirX, dirY));
            rover.Move();
            Assert.Equal(posX + dirX, rover.Position.X);
            Assert.Equal(posY + dirY, rover.Position.Y);
            Assert.Equal(dirX, rover.Direction.X);
            Assert.Equal(dirY, rover.Direction.Y);
        }

        [Theory]
        [AutoData]
        public void WhenRoverMovedOutsidePlain_Throws(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(true, false);
            var rover = new Rover(this.plain, (posX, posY), (dirX, dirY));
            var error = Assert.Throws<ArgumentException>(() => rover.Move());
            Assert.Equal("Final position outside Plain.", error.Message);
        }

        [Theory]
        [AutoData]
        public void WhenRoverRotatedLeft_HasSamePositionOnPlainAndNewDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
            var rover = new Rover(this.plain, (posX, posY), (dirX, dirY));
            rover.RotateLeft();
            Assert.Equal(posX, rover.Position.X);
            Assert.Equal(posY, rover.Position.Y);
            Assert.Equal(-1 * dirY, rover.Direction.X);
            Assert.Equal(dirX, rover.Direction.Y);
        }

        [Theory]
        [AutoData]
        public void WhenRoverRotatedRight_HasSamePositionOnPlainAndNewDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
            var rover = new Rover(this.plain, (posX, posY), (dirX, dirY));
            rover.RotateRight();
            Assert.Equal(posX, rover.Position.X);
            Assert.Equal(posY, rover.Position.Y);
            Assert.Equal(dirY, rover.Direction.X);
            Assert.Equal(-1 * dirX, rover.Direction.Y);
        }
    }

#pragma warning restore SA1009 // Closing parenthesis must be spaced correctly
}