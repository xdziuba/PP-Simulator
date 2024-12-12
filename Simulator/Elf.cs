using System;

namespace Simulator;

public class Elf : Creature
{
    private int singCount = 0;
    private int agility = 1;
    public int Agility
    {
        get { return agility; }
        init
        {
            if (value < 0)
            {
                agility = 0;
            }
            else if (value > 10)
            {
                agility = 10;
            }
            else
            {
                agility = value;
            }
        }
    }

    public override int Power => 8 * Level + 2 * agility;

    public Elf() { }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public void Sing()
    {
        singCount++;
        Console.WriteLine($"{Name} is singing.");
        if (singCount >= 3 && agility < 10)
        {
            agility++;
            singCount = 0;
        }
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
}
