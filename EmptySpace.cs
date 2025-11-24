namespace MazeGame
{
    public class EmptySpace : IMazeObject
    {
        public char Icon { get => ' '; }
        public bool IsSolid { get => false ; }
    }
}