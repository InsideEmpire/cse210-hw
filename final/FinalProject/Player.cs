class Player
{
    private int _x;
    private int _y;
    private bool _hasKey;

    public Player()
    {
        _x = 1;
        _y = 1;
        _hasKey = false;

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
}