namespace MarsRover.Tests
{
    using AutoFixture.Xunit2;
    using MarsRover.Engine;
    using MarsRover.Engine.RoverCommands;
    using NSubstitute;
    using System;
    using Xunit;

    public class MoveCommandTests
    {
        private readonly IPlain plain = Substitute.For<IPlain>();

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
            new Move().Execute(rover);
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
            var error = Assert.Throws<ArgumentException>(() => new Move().Execute(rover));
            Assert.Equal("Final position outside Plain.", error.Message);
        }
    }
}