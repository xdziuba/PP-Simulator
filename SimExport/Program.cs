using Simulator;
using Simulator.Maps;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimExport;

internal class Program
{
    static void Main(string[] args)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        };

        SmallTorusMap map = new(8, 6);

        List<IMappable> creatures = [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals{ Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
            ];

        List<Point> points = [
            new(2, 2),
            new(3, 1),
            new(3, 2),
            new(6, 5),
            new(5, 5)
            ];

        string moves = "rlrludlruddurlr";
        
        JSONSimDef simDef = new JSONSimDef { Map=map, Mappables=creatures, Moves=moves, Points=points };

        using (FileStream fs = new FileStream("SimDef.json", FileMode.Create))
        {
            JsonSerializer.Serialize(fs, simDef, options);
        }
        //string json = JsonSerializer.Serialize(simDef, options);
        //Console.WriteLine(json);
        //JSONSimDef deserializedsimDef = JsonSerializer.Deserialize<JSONSimDef>(json, options)!;

        //Simulation sim = new(map, creatures, points, moves);
        //SimulationHistory simHistory = new SimulationHistory(sim);

    }
}
