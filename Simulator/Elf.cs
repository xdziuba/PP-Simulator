using System;
using System.Text.Json.Serialization;

namespace Simulator;

public class Elf : Creature
{
    private int singCount = 0;
    private int agility = 1;
    public int Agility
    {
        get { return agility; }
        init { agility = Validator.Limiter(value, 0, 10); }
    }

    [JsonIgnore]
    public override int Power => 8 * Level + 2 * agility;
    [JsonIgnore]
    public override char Symbol => 'E';

    public Elf() { }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public void Sing()
    {
        singCount++;
        if (singCount >= 3 && agility < 10)
        {
            agility++;
            singCount = 0;
        }
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    [JsonIgnore]
    public override string Info => $"{Name} [{Level}][{Agility}]";
}
