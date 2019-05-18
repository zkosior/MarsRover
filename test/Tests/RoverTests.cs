namespace MarsRover.Tests
{
    using AutoFixture.Xunit2;
    using MarsRover.Engine;
    using System;
    using Xunit;

    [Trait("TestCategory", "Unit")]
    public class RoverTests
    {
        [Theory]
        [AutoData]
        public void WhenRoverCreated_HasPositionOnPlainAndDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            var rover = new Rover((posX, posY), (dirX, dirY));
            Assert.Equal(posX, rover.Position.X);
            Assert.Equal(posY, rover.Position.Y);
            Assert.Equal(dirX, rover.Direction.X);
            Assert.Equal(dirY, rover.Direction.Y);
        }

        [Theory]
        [AutoData]
        public void WhenRoverMoved_HasNewPositionOnPlainAndSameDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            var rover = new Rover((posX, posY), (dirX, dirY));
            rover.Move();
            Assert.Equal(posX + dirX, rover.Position.X);
            Assert.Equal(posY + dirY, rover.Position.Y);
            Assert.Equal(dirX, rover.Direction.X);
            Assert.Equal(dirY, rover.Direction.Y);
        }

        [Theory]
        [AutoData]
        public void WhenRoverRotatedLeft_HasSamePositionOnPlainAndNewDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            var rover = new Rover((posX, posY), (dirX, dirY));
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
            var rover = new Rover((posX, posY), (dirX, dirY));
            rover.RotateRight();
            Assert.Equal(posX, rover.Position.X);
            Assert.Equal(posY, rover.Position.Y);
            Assert.Equal(dirY, rover.Direction.X);
            Assert.Equal(-1 * dirX, rover.Direction.Y);
        }
    }
}