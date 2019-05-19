namespace MarsRover.Engine.RoverCommands
{
    public interface ICommand
    {
        void Execute(Rover rover);
    }
}