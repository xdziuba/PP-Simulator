namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public readonly List<IMappable>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
        {
            throw new ArgumentOutOfRangeException("Blad! - Maksymalny rozmiar mapy to 20 punktow.");
        }
        _fields = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(IMappable inter, Point point)
    {
        if (!Exist(point)) {
            throw new ArgumentOutOfRangeException("Blad! - Wskazany punkt nie nalezy do mapy.");
        }
        if (_fields[point.X, point.Y] == null)
        {
            _fields[point.X, point.Y] = new List<IMappable>();
        }
        _fields[point.X, point.Y]!.Add(inter);
    }

    public override void Remove(IMappable inter, Point point)
    {
        if (_fields[point.X, point.Y] != null)
        {
            _fields[point.X, point.Y]!.Remove(inter);
        }
    }

    public override List<IMappable> At(Point point) {
        if (_fields[point.X, point.Y] != null)
        {
            return _fields[point.X, point.Y]!;
        }
        else
        {
            return new List<IMappable>();
        }
    }

    public override List<IMappable> At(int x, int y)
    {
        Point point = new Point(x, y);
        return At(point);
    }

}
