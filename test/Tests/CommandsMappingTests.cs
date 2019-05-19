namespace MarsRover.Tests
{
    using MarsRover.Engine.Language;
    using MarsRover.Engine.RoverCommands;
    using System;
    using Xunit;

    public class CommandsMappingTests
    {
        [Fact]
        public void MapsLeftRotation()
        {
            Assert.IsType<RotateLeft>(Commands.DecodeCommand('L'));
        }

        [Fact]
        public void MapsRightRotation()
        {
            Assert.IsType<RotateRight>(Commands.DecodeCommand('R'));
        }

        [Fact]
        public void MapsMove()
        {
            Assert.IsType<Move>(Commands.DecodeCommand('M'));
        }

        [Fact]
        public void NotSupportedMap()
        {
            Assert.Throws<InvalidOperationException>(
                () => Commands.DecodeCommand('O'));
        }

        [Fact]
        public void AllowedCommands()
        {
            Assert.Equal(Commands.AllowedCommands, new[] { 'M', 'L', 'R' });
        }
    }
}