abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected int _completedTimes;

    public Goal()
    {
        _completedTimes = 0;
    }

    public abstract int RecordEvent();
    public abstract bool IsCompleted();
    protected virtual void SetName()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
    }
    protected virtual void SetDescription()
    {
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
    }
    protected virtual void SetPoints()
    {
        Console.Write("What is the amonut of points associated with this goal? ");
        _points = int.Parse(Console.ReadLine());
    }
    public abstract int GetPoints();
    public virtual void Display()
    {
        Console.WriteLine($"[{(IsCompleted() ? 'x' : ' ')}] {_name} ({_description})");
    }
    public virtual string GetName()
    {
        return _name;
    }
    public abstract string GetStringRepresentation();
}