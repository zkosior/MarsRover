namespace MarsRover.Tests
{
    using MarsRover.Engine;
    using Xunit;

    public class InputParserTests
    {
        [Theory]
        [InlineData("5 5", 5, 5)]
        [InlineData("15 25", 15, 25)]
        public void CorrectPlainSetupConfig_ReturnsTrueAndSize(
            string input,
            int x,
            int y)
        {
            Assert.True(InputParser.TryGetPlainSetup(input, out var size));
            Assert.Equal((x, y), size);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("M 5")]
        [InlineData("5 M")]
        [InlineData("5,5")]
        [InlineData("5 5 5")]
        [InlineData("5 -5")]
        [InlineData("-5 5")]
        public void IncorrectPlainSetupConfig_ReturnsFalse(string input)
        {
            Assert.False(InputParser.TryGetPlainSetup(input, out _));
        }

        [Theory]
        [InlineData("1 2 N", 1, 2, 'N')]
        [InlineData("0 0 N", 0, 0, 'N')]
        public void CorrectRoverSetupConfig_ReturnsTrueAndParameters(
            string input,
            int x,
            int y,
            char d)
        {
            var allowedCharacters = new[] { 'N', 'R' };
            Assert.True(InputParser.TryGetRoverSetup(
                input,
                allowedCharacters,
                out var position,
                out var direction));
            Assert.Equal((x, y), position);
            Assert.Equal(d, direction);
        }

        [Theory]
        [InlineData("1 2 E")]
        [InlineData("1 2 3")]
        [InlineData("1 2 3 N")]
        [InlineData("1 N 2")]
        [InlineData("N 2 3")]
        [InlineData("1 2")]
        [InlineData("")]
        [InlineData("1,2,N")]
        [InlineData("1 2 NN")]
        [InlineData("-1 2 N")]
        [InlineData("1 -2 N")]
        public void IncorrectRoverSetupConfig_ReturnsFalse(string input)
        {
            var allowedCharacters = new[] { 'N', 'R' };
            Assert.False(InputParser.TryGetRoverSetup(
                input,
                allowedCharacters,
                out _,
                out _));
        }

        [Theory]
        [InlineData("LMLMLMLMM")]
        public void CorrectCommandsConfig_ReturnsTrueAndCommands(
            string input)
        {
            var allowedCharacters = new[] { 'M', 'L' };
            Assert.True(InputParser.TryGetCommands(
                input,
                allowedCharacters,
                out var commands));
            Assert.Equal(input, commands);
        }

        [Theory]
        [InlineData("LMLMLMLMMNNNNN")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("LM LM LM")]
        [InlineData("LMLMLMLMM1")]
        [InlineData("1")]
        public void IncorrectCommandsConfig_ReturnsFalse(
            string input)
        {
            var allowedCharacters = new[] { 'M', 'L' };
            Assert.False(InputParser.TryGetCommands(
                input,
                allowedCharacters,
                out _));
        }
    }
}