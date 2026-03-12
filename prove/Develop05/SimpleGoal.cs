class SimpleGoal : Goal
{
    public SimpleGoal()
        : base()
    {
        SetName();
        SetDescription();
        SetPoints();
    }
    public SimpleGoal(string[] parts)
        : base()
    {
        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _completedTimes = int.Parse(parts[4]);
    }
    public override int RecordEvent()
    {
        _completedTimes += 1;
        return _points;
    }
    public override bool IsCompleted()
    {
        if (_completedTimes == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override int GetPoints()
    {
        if (IsCompleted())
        {
            return _points;
        }
        else
        {
            return 0;
        }
    }
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_completedTimes}";
    }
}