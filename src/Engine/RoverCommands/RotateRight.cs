namespace MarsRover.Engine.RoverCommands
{
    public class RotateRight : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.RotateRight();
        }
    }
}