namespace MarsRover.Engine
{
    using MarsRover.Engine.RoverCommands;

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class Rover
    {
        public Rover(
            IPlain plain,
            (int X, int Y) position,
            (int X, int Y) direction)
        {
            if (!plain.IsPositionValid(position.X, position.Y))
                throw new System.ArgumentException("Position not on Plain.");

            this.Plain = plain;
            this.Position = position;
            this.Direction = direction;
        }

        public (int X, int Y) Position { get; set; }

        public (int X, int Y) Direction { get; set; }

        public IPlain Plain { get; set; }

        public void Execute(ICommand command) =>
            command.Execute(this);
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}