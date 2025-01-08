﻿namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        return direction switch
        {
            Direction.Left => new Point(X - 1, Y),
            Direction.Right => new Point(X + 1, Y),
            Direction.Up => new Point(X, Y - 1),
            Direction.Down => new Point(X, Y + 1),
            _ => throw new NotSupportedException()
        };
    }

    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        return direction switch
        {
            Direction.Left => new Point(X - 1, Y + 1),
            Direction.Right => new Point(X + 1, Y - 1),
            Direction.Up => new Point(X + 1, Y + 1),
            Direction.Down => new Point(X - 1, Y - 1),
            _ => throw new NotSupportedException()
        };
    }
}
