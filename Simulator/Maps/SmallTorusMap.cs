namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

    }
    private Point CorrectTorusPos(Point point)
    {
        var x = point.X;
        var y = point.Y;

        while (x < 0)
        {
            x += SizeX;
        }
        while (x >= SizeX)
        {
            x -= SizeX;
        }

        while (y < 0)
        {
            y += SizeY;
        }
        while (y >= SizeY)
        {
            y -= SizeY;
        }

        return new Point(x, y);
    }

    public override Point Next(Point p, Direction d)
    {
        return CorrectTorusPos(p.Next(d));
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return CorrectTorusPos(p.NextDiagonal(d));
    }
}
