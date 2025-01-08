namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public readonly List<Creature>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
        {
            throw new ArgumentOutOfRangeException("Blad! - Maksymalny rozmiar mapy to 20 punktow.");
        }
        _fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point point)
    {
        if (!Exist(point)) {
            throw new ArgumentOutOfRangeException("Blad! - Wskazany punkt nie nalezy do mapy.");
        }
        if (_fields[point.X, point.Y] == null)
        {
            _fields[point.X, point.Y] = new List<Creature>();
        }
        _fields[point.X, point.Y]!.Add(creature);
    }

    public override void Remove(Creature creature, Point point)
    {
        if (_fields[point.X, point.Y] != null)
        {
            _fields[point.X, point.Y]!.Remove(creature);
        }
    }

    public override List<Creature> At(Point point) {
        if (_fields[point.X, point.Y] != null)
        {
            return _fields[point.X, point.Y]!;
        }
        else
        {
            return new List<Creature>();
        }
    }

    public override List<Creature> At(int x, int y)
    {
        Point point = new Point(x, y);
        return At(point);
    }

}
