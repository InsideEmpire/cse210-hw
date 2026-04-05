using System.Collections.Generic;

class Map
{
    private Tile[,] _map;
    private int _width = 11;
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

        PlaceKeyRandomly();
        
        PlaceDoorRandomly();
    }

    private void PlaceKeyRandomly()
    {
        List<(int, int)> floorTiles = new List<(int, int)>();
        
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                if (_map[i, j] is FloorTile)
                {
                    floorTiles.Add((i, j));
                }
            }
        }
        
        if (floorTiles.Count > 0)
        {
            int index = _rand.Next(floorTiles.Count);
            var (x, y) = floorTiles[index];
            _map[x, y] = new KeyTile();
        }
    }

    private void PlaceDoorRandomly()
    {
        List<(int, int)> wallTiles = new List<(int, int)>();
        
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                if (_map[i, j] is WallTile)
                {
                    bool nearFloor = false;
                    if (i > 0 && _map[i-1, j] is FloorTile) nearFloor = true;
                    if (i < _width-1 && _map[i+1, j] is FloorTile) nearFloor = true;
                    if (j > 0 && _map[i, j-1] is FloorTile) nearFloor = true;
                    if (j < _length-1 && _map[i, j+1] is FloorTile) nearFloor = true;
                    
                    if (nearFloor)
                    {
                        wallTiles.Add((i, j));
                    }
                }
            }
        }
        
        if (wallTiles.Count > 0)
        {
            int index = _rand.Next(wallTiles.Count);
            var (x, y) = wallTiles[index];
            _map[x, y] = new DoorTile();
        }
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
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                if (i == playerX && j == playerY)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("P");
                }
                else
                {
                    Tile tile = _map[i, j];
                    if (tile is WallTile)
                        Console.ForegroundColor = ConsoleColor.Gray;
                    else if (tile is FloorTile)
                        Console.ForegroundColor = ConsoleColor.White;
                    else if (tile is KeyTile)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (tile is DoorTile)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(tile.GetSymbol());
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public void SetFloorTile(int x, int y)
    {
        _map[x, y] = new FloorTile();
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

    public bool IsKey(int x, int y)
    {
        if (x < 0 || y < 0 || x >= _width || y >= _length)
            return false;

        return _map[x, y] is KeyTile;
    }

    public bool IsDoor(int x, int y)
    {
        if (x < 0 || y < 0 || x >= _width || y >= _length)
            return false;

        return _map[x, y] is DoorTile;
    }
}