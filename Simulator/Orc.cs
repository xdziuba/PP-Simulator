namespace Simulator;

public class Orc : Creature
{
    private int huntCount = 0;
    private int rage = 1;
    public int Rage
    {
        get { return rage; }
        init
        {
            if (value < 0)
            {
                rage = 0;
            }
            else if (value > 10)
            {
                rage = 10;
            }
            else
            {
                rage = value;
            }
        }
    }

    public override int Power => 7*Level + 3*rage;

    public Orc() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        huntCount++;
        Console.WriteLine($"{Name} is hunting.");
        if (huntCount >= 3 && rage < 10)
        {
            rage++;
            huntCount = 0;
        }
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
}
