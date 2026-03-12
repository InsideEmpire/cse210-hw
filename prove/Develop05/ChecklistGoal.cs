class ChecklistGoal : Goal
{
    private int _target;
    private int _bonusPoints;

    public ChecklistGoal()
        : base()
    {
        SetName();
        SetDescription();
        SetPoints();
        SetTarget();
        SetBonusPoints();
    }
    public ChecklistGoal(string[] parts)
        : base()
    {
        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _completedTimes = int.Parse(parts[4]);
        _target = int.Parse(parts[5]);
        _bonusPoints = int.Parse(parts[6]);
    }
    public override int RecordEvent()
    {
        _completedTimes += 1;
        if (IsCompleted())
        {
            return _bonusPoints;
        }
        else
        {
            return _points;
        }
    }
    public override bool IsCompleted()
    {
        if (_completedTimes >= _target)
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
            return _target * _points + (_completedTimes - _target) * _bonusPoints;
        }
        else
        {
            return _completedTimes * _points;
        }
    }
    public void SetTarget()
    {
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _target = int.Parse(Console.ReadLine());
    }
    public void SetBonusPoints()
    {
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusPoints = int.Parse(Console.ReadLine());
    }
    public override void Display()
    {
        Console.WriteLine($" [{(IsCompleted() ? 'x' : ' ')}] {_name} ({_description}) -- Currently completed: {_completedTimes}/{_target}");
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_completedTimes}|{_target}|{_bonusPoints}";
    }
}