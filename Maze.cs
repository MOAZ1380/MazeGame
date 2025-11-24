namespace MazeGame
{
    public class Maze
    {
        private int _Width;
        private int _Height;
        private Player _Player;
        private IMazeObject[,] _MazeGrid;

        private int ExitX;
        private int ExitY;

        public Maze(int width, int height){
            _Width = width;
            _Height = height;
            _MazeGrid = new IMazeObject[width, height];
            _Player = new Player() { X = 1, Y = 1 };

            ExitX = width - 2;
            ExitY = height - 2;
        }
            



        public void DrawMaze(){
            Console.Clear();
            for (int y = 0; y < _Height; y++)
            {
                for (int x = 0; x < _Width; x++)
                {
                    // Create walls around the maze and an exit
                    if (x == ExitX && y == ExitY)
                    {
                        _MazeGrid[x, y] = new EmptySpace();
                        Console.Write("E"); // Exit icon
                    }

                    if (x == 0 || y == 0 || x == _Width - 1 || y == _Height - 1)
                    {
                        _MazeGrid[x, y] = new Wall();
                        Console.Write(_MazeGrid[x, y].Icon);
                    }
                    else if (x == _Player.X && y == _Player.Y)
                    {
                        Console.Write(_Player.Icon);
                    }
                    else if ((x % 4 == 0 && y % 3 == 0) || (x % 6 == 0 && y % 5 == 0))
                    {
                        _MazeGrid[x, y] = new Wall();
                        Console.Write(_MazeGrid[x, y].Icon);
                    }
                    else // Empty space
                    {
                        _MazeGrid[x, y] = new EmptySpace();
                        Console.Write(_MazeGrid[x, y].Icon);
                    }

                }
                Console.WriteLine();
            }
        }


        private void UpdatePlayer(int dx, int dy){
            int newX = _Player.X + dx;
            int newY = _Player.Y + dy;

            // Check boundaries
            if (newX < 0 || newX >= _Width || newY < 0 || newY >= _Height || _MazeGrid[newX, newY].IsSolid == true)
            {
                return; // Out of bounds, do not move
            }

            _Player.X = newX;
            _Player.Y = newY;


            if (_Player.X == ExitX && _Player.Y == ExitY)
            {
                DrawMaze();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🎉 Congratulations! You escaped the maze! 🎉");
                Console.ResetColor();
                Environment.Exit(0);
            }

            DrawMaze();

        }



        public void MovePlayer(){
            ConsoleKeyInfo userInput = Console.ReadKey();
            ConsoleKey key = userInput.Key;


            switch (key)
            {

                case ConsoleKey.UpArrow:
                    UpdatePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(1, 0);
                    break;
                default:
                    break;
            }
        }
    }


}