namespace IJ_homeWork_propertys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player('@', 99999, -30);
            Renderer renderer = new Renderer();

            renderer.DrawPlayer(player);
            Console.ReadKey();
        }
    }

    class Player
    {
        private int _xPosition;
        private int _yPosition;
        private char _symbol;

        public Player(char symbol, int xPosition, int yPosition)
        {
            _symbol = symbol;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public int XPosition
        {
            get
            {
                return _xPosition;
            }
            set
            {
                _xPosition = SetPosition(value, Direction.X);
            }
        }

        public int YPosition
        {
            get
            {
                return _yPosition;
            }
            set
            {
                _yPosition = SetPosition(value, Direction.Y);
            }
        }

        public char Symbol { get { return _symbol; } private set { } }

        private int SetPosition(int value, Direction direction)
        {
            if (value < 0)
            {
                return 0;
            }
            else if (direction == Direction.X && value > Console.BufferWidth)
            {
                return Console.BufferWidth - 1;
            }
            else if (direction == Direction.Y && value > Console.BufferHeight)
            {
                return Console.BufferHeight - 1;
            }

            return value;
        }
    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.XPosition, player.YPosition);
            Console.Write(player.Symbol);
        }
    }

    enum Direction
    {
        X,
        Y
    }
}