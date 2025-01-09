﻿namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public readonly Rectangle _map;

    public abstract void Add(IMappable inter, Point point);
    public abstract void Remove(IMappable inter, Point point);
    public void Move(IMappable inter, Point pos, Point nextpos)
    {
        Remove(inter, pos);
        Add(inter, nextpos);
    }
    public abstract List<IMappable> At(Point point);
    public abstract List<IMappable> At(int x, int y);

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException("Blad! - Minimalny rozmiar mapy to 5 punktow.");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public bool Exist(Point p)
    {
        return _map.Contains(p);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
