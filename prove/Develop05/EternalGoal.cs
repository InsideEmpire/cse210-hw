class EternalGoal : Goal
{
    public EternalGoal()
        : base()
    {
        SetName();
        SetDescription();
        SetPoints();
    }
    public EternalGoal(string[] parts)
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
        return false;
    }
    public override int GetPoints()
    {
        return _completedTimes * _points;
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}|{_completedTimes}";
    }
}