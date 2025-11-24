namespace MazeGame
{
    public interface IMazeObject
    {
        char Icon { get;} //the shape of the maze object
        bool IsSolid { get; } // movement blocking
    }
}