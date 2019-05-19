namespace MarsRover.Engine.RoverCommands
{
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

    public class Move : ICommand
    {
        public void Execute(Rover rover)
        {
            var newX = rover.Position.X + rover.Direction.X;
            var newY = rover.Position.Y + rover.Direction.Y;
            if (!rover.Plain.IsPositionValid(newX, newY))
                throw new System.ArgumentException("Final position outside Plain.");
            rover.Position = (newX, newY);
        }
    }

#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
}