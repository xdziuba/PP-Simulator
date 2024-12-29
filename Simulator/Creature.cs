using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

    public abstract string Greeting();

    public abstract string Info { get; }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        List<string> moves = new List<string>();
        foreach (Direction direction in directions)
        {
            moves.Add(Go(direction));
        }
        return moves.ToArray();
    }

    public string[] Go(string directions) => Go(DirectionParser.Parse(directions));
}