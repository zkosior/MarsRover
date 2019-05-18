namespace MarsRover.Engine
{
    public interface IPlain
    {
        bool IsPositionValid((int, int) p);
    }
}