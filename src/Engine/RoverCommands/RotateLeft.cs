namespace MarsRover.Engine.RoverCommands
{
    public class RotateLeft : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.RotateLeft();
        }
    }
}