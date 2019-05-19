namespace MarsRover.Engine.RoverCommands
{
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class RotateRight : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.Direction = (rover.Direction.Y, rover.Direction.X * -1);
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}