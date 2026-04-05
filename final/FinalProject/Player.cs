class Player
{
    private int _x;
    private int _y;
    private bool _hasKey;
    private int _score;

    public Player()
    {
        _x = 1;
        _y = 1;
        _hasKey = false;
        _score = 0;

    }
    public int GetX()
    {
        return _x;
    }
    public int GetY()
    {
        return _y;
    }
    public void SetX(int x)
    {
        _x = x;
    }
    public void SetY(int y)
    {
        _y = y;
    }
    public bool GetHasKey()
    {
        return _hasKey;
    }
    public void SetHasKey(bool hasKey)
    {
        _hasKey = hasKey;
    }
    public int GetScore()
    {
        return _score;
    }
    public void AddScore(int points)
    {
        _score += points;
    }
}