namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public abstract int Power { get; }

    public string Name
    {
        get { return name; }
        init { name = Validator.Shortener(value, 3, 25, '#'); }
    }

    public int Level
    {
        get { return level; }
        init { level = Validator.Limiter(value, 1, 10); }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract void SayHi();

    public abstract string Info { get; }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public void Go(Direction direction)
    {
        string directionName = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionName}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }
}