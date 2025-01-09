﻿namespace Simulator;

public class Orc : Creature
{
    private int huntCount = 0;
    private int rage = 1;
    public int Rage
    {
        get { return rage; }
        init { rage = Validator.Limiter(value, 0, 10); }
    }

    public override int Power => 7*Level + 3*rage;
    public override char Symbol => 'O';

    public Orc() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        huntCount++;
        if (huntCount >= 3 && rage < 10)
        {
            rage++;
            huntCount = 0;
        }
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    public override string Info => $"{Name} [{Level}][{Rage}]";
}
