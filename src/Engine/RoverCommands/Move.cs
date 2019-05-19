namespace MarsRover.Engine.RoverCommands
{
    public class Move : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.Move();
        }
    }
}