namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public abstract int Power { get; }

    public string Name
    {
        get { return name; }
        init 
        {
            if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
            }

            value = value.Trim();

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }
            name = value;
        }
    }

    public int Level
    {
        get { return level; }
        init
        {
            if (value < 1)
            {
                level = 1;
            }
            else if (value > 10)
            {
                level = 10;
            }
            else
            {
                level = value;
            }
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract void SayHi();

    public string Info => $"{Name} [{Level}]";

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