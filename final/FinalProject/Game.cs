using System;

class Game
{
    private Map _map;
    private Player _player;

    public Game()
    {
        _map = new Map();
        _map.GenerateMap();
        _player = new Player();
    }
    private void Move()
    {
        char key = Console.ReadKey().KeyChar;
        switch (key)
        {
            case 'a':
            case 'A':
                if (_map.IsWalkable(_player.GetX(), _player.GetY() - 1))
                {
                    _player.SetY(_player.GetY() - 1);
                }
                break;
            case 'd':
            case 'D':
                if (_map.IsWalkable(_player.GetX(), _player.GetY() + 1))
                {
                    _player.SetY(_player.GetY() + 1);
                }
                break;
            case 'w':
            case 'W':
                if (_map.IsWalkable(_player.GetX() - 1, _player.GetY()))
                {
                    _player.SetX(_player.GetX() - 1);
                }
                break;
            case 's':
            case 'S':
                if (_map.IsWalkable(_player.GetX() + 1, _player.GetY()))
                {
                    _player.SetX(_player.GetX() + 1);
                }
                break;
            default:
                break;
        }

        if (_map.IsKey(_player.GetX(), _player.GetY()))
        {
            _map.SetFloorTile(_player.GetX(), _player.GetY());
            _player.SetHasKey(true);
            _player.AddScore(10);
        } 
        else if (_map.IsDoor(_player.GetX(), _player.GetY()) && _player.GetHasKey())
        {
            _map.GenerateMap();
            _player.SetHasKey(false);
            _player.SetX(1);
            _player.SetY(1);
            _player.AddScore(50);
        }
    }

    public void Run()
    {
        Console.Clear();
        _map.DrawMap(_player.GetX(), _player.GetY());
        do
        {
            Move();
            _map.DrawMap(_player.GetX(), _player.GetY());
            Console.SetCursorPosition(0, 11);
            Console.WriteLine($"Key: {_player.GetHasKey()} | Score: {_player.GetScore()}");
        } while (true);
    }
}