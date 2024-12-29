using Simulator;
using Simulator.Maps;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }

    public static void Lab5a()
    {
        try
        {
            Map map1 = new SmallSquareMap(1);
        }
        catch (Exception ex)
        { Console.WriteLine(ex.Message); }

        try
        {
            Map map2 = new SmallSquareMap(22);
        }
        catch (Exception ex)
        { Console.WriteLine(ex.Message); }

        Map map = new SmallSquareMap(5);

        Point point1 = new Point(6, 4);
        Point point2 = new Point(3, 3);
        Console.WriteLine(map.Exist(point1));
        Console.WriteLine(map.Exist(point2));

        Console.WriteLine(map.Next(point2, Direction.Left));
        Console.WriteLine(map.NextDiagonal(point2, Direction.Left));
    }
}
