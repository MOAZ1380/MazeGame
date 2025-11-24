namespace MazeGame
{
    internal class Wall : IMazeObject
    {
        // Interface members go here
        public char Icon { get => '#'; }
        public bool IsSolid { get => true; }
    }
}