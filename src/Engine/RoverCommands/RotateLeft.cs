namespace MarsRover.Engine.RoverCommands
{
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class RotateLeft : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.Direction = (rover.Direction.Y * -1, rover.Direction.X);
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}