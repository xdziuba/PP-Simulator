using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        int turn = 1;
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludlru";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine("\nStarting positions:");
        mapVisualizer.Draw();

        while (simulation.Finished == false)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine($"\nTurn: {turn}");
            Console.WriteLine($"{simulation.CurrentCreature} {simulation.CurrentCreature.CreaturePos} goes {simulation.CurrentMoveName}:");
            simulation.Turn();
            mapVisualizer.Draw();
            turn++;
        }
    }
}
