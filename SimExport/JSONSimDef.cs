using Simulator;
using Simulator.Maps;

namespace SimExport;


public class JSONSimDef
{
    public required SmallTorusMap Map { get; init; }
    public required List<IMappable> Mappables { get; init; }
    public required List<Point> Points { get; init; }
    public required string Moves { get; init; }
}