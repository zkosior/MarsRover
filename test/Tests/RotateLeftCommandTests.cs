namespace MarsRover.Tests
{
    using AutoFixture.Xunit2;
    using MarsRover.Engine;
    using MarsRover.Engine.RoverCommands;
    using NSubstitute;
    using Xunit;

    public class RotateLeftCommandTests
    {
        private readonly IPlain plain = Substitute.For<IPlain>();

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
            new RotateLeft().Execute(rover);
            Assert.Equal(posX, rover.Position.X);
            Assert.Equal(posY, rover.Position.Y);
            Assert.Equal(-1 * dirY, rover.Direction.X);
            Assert.Equal(dirX, rover.Direction.Y);
        }

        [Theory]
        [AutoData]
        public void FourLeftRotations_ReturnsToTheSamePositionAndDirection(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
            var rover = new Rover(this.plain, (posX, posY), (dirX, dirY));
            var command = new RotateLeft();
            command.Execute(rover);
            command.Execute(rover);
            command.Execute(rover);
            command.Execute(rover);
            Assert.Equal(posX, rover.Position.X);
            Assert.Equal(posY, rover.Position.Y);
            Assert.Equal(dirX, rover.Direction.X);
            Assert.Equal(dirY, rover.Direction.Y);
        }
    }
}