namespace MarsRover.Tests
{
    using AutoFixture.Xunit2;
    using MarsRover.Engine;
    using MarsRover.Engine.RoverCommands;
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
        public void ExecutesCommands(
            int posX,
            int posY,
            int dirX,
            int dirY)
        {
            this.plain.IsPositionValid(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
            var rover = new Rover(this.plain, (posX, posY), (dirX, dirY));
            var command = Substitute.For<ICommand>();

            rover.Execute(command);
            command.Received(1).Execute(Arg.Is(rover));
        }
    }

#pragma warning restore SA1009 // Closing parenthesis must be spaced correctly
}