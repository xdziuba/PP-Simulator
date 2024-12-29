namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }
    private readonly Rectangle _map;

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Blad! - Poprawny rozmiar mapy to od od 5 do 20 punktow.");
        }
        Size = size;
        _map = new Rectangle(0, 0, Size - 1, Size - 1);

    }
    private Point CorrectTorusPos(Point point)
    {
        var x = point.X;
        var y = point.Y;

        while (x < 0)
        {
            x += Size;
        }
        while (x >= Size)
        {
            x -= Size;
        }

        while (y < 0)
        {
            y += Size;
        }
        while (y >= Size)
        {
            y -= Size;
        }

        return new Point(x, y);
    }

    public override bool Exist(Point p)
    {
        return _map.Contains(p);
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
