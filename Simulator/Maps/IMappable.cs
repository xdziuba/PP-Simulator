namespace Simulator.Maps;

public interface IMappable
{
    void AssignMap(Map map, Point point);
    string Go(Direction direction);
    string ToString();
    Point GetPos();
}
