namespace MazeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Maze Game!");
            Console.WriteLine("use keyboard Arrow keys to move the player '@' through the maze.");

            Maze maze = new Maze(40, 20);

            while (true)
            {
                maze.DrawMaze();
                maze.MovePlayer();
            }
            
        }
    }
}