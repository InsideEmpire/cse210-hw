class Map
{
    private Tile[,] _map;
    private int _width = 21;
    private int _length = 21;
    private Random _rand = new Random();

    public void GenerateMap()
    {
        _map = new Tile[_width, _length];

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                _map[i, j] = new WallTile();
            }
        }

        GenerateMaze(1, 1);

        _map[1, _length - 2] = new KeyTile();
        _map[_width - 2, _length - 2] = new DoorTile();
    }

    private void GenerateMaze(int x, int y)
    {
        _map[x, y] = new FloorTile();

        int[] dx = { 0, 0, 2, -2 };
        int[] dy = { 2, -2, 0, 0 };

        for (int i = 0; i < 4; i++)
        {
            int r = _rand.Next(i, 4);

            int temp = dx[i];
            dx[i] = dx[r];
            dx[r] = temp;

            temp = dy[i];
            dy[i] = dy[r];
            dy[r] = temp;
        }

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];

            if (nx > 0 && ny > 0 && nx < _width - 1 && ny < _length - 1)
            {
                if (_map[nx, ny] is WallTile)
                {
                    _map[x + dx[i] / 2, y + dy[i] / 2] = new FloorTile();

                    GenerateMaze(nx, ny);
                }
            }
        }
    }

    public void DrawMap(int playerX, int playerY)
    {
        Console.Clear();
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                if (i == playerX && j == playerY)
                {
                    Console.Write('P');
                }
                else
                {
                    Console.Write(_map[i, j].GetSymbol());
                }
            }
            Console.WriteLine();
        }
    }

    public Tile GetTile(int x, int y)
    {
        return _map[x, y];
    }

    public bool IsWalkable(int x, int y)
    {
        if (x < 0 || y < 0 || x >= _width || y >= _length)
            return false;

        return !(_map[x, y] is WallTile);
    }
}