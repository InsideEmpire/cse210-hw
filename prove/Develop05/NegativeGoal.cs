class NegativeGoal : Goal
{
    public NegativeGoal()
        : base()
    {
        SetName();
        SetDescription();
        SetPoints();
    }
    public NegativeGoal(string[] parts)
        : base()
    {
        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _completedTimes = int.Parse(parts[4]);
    }
    protected override void SetPoints()
    {
        Console.Write("What is the amonut of points associated with this goal? ");
        _points = int.Parse(Console.ReadLine());
        if (_points > 0)
        {
            _points = -1 * _points;
        }
    }
    public override int RecordEvent()
    {
        _completedTimes += 1;
        return _points;
    }
    public override bool IsCompleted()
    {
        return false;
    }
    public override int GetPoints()
    {
        return _completedTimes * _points;
    }
    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_name}|{_description}|{_points}|{_completedTimes}";
    }
}