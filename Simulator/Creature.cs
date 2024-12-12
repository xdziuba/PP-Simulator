namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    private int level = 1;

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

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
    public string Info => $"{Name} [{Level}]";

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }
}