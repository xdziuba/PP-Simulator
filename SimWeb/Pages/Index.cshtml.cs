using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;
using System.Text.Json;
using SimExport;
using System.Text.Json.Serialization;

namespace First.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public IFormFile File { get; set; }
    public int Turn { get; private set; } = 0;
    public SimulationTurnLog CurrentLog { get; private set; }
    public int SizeX { get; } = 8;
    public int SizeY { get; } = 6;

    public Simulation Simulation { get; private set; }
    public SimulationHistory SimHistory { get; private set; }

    public void SimInit(JSONSimDef? simDef=null)
    {
        SmallTorusMap map;
        List<IMappable> creatures;
        List<Point> points;
        string moves;

        if (simDef == null)
        {
            map = new(SizeX, SizeY);

            creatures = [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals{ Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
            ];

            points = [
            new(2, 2),
            new(3, 1),
            new(3, 2),
            new(6, 5),
            new(5, 5)
            ];

            moves = "rlrludlruddurlr";
        }
        else
        {
            map = simDef.Map;
            creatures = simDef.Mappables;
            points = simDef.Points;
            moves = simDef.Moves;
        }
        
        Simulation = new(map, creatures, points, moves);
        SimHistory = new SimulationHistory(Simulation);
        CurrentLog = SimHistory.TurnLogs[Turn];
    }

    public void OnGet()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (HttpContext.Session.GetString("SimJSON") != null)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            JSONSimDef jsonObject = JsonSerializer.Deserialize<JSONSimDef>(HttpContext.Session.GetString("SimJSON")!, options)!;
            SimInit(jsonObject);
        }
        else
        {
            SimInit();
        }
    }

    public void OnPostNextTurn()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (HttpContext.Session.GetString("SimJSON") != null)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            JSONSimDef jsonObject = JsonSerializer.Deserialize<JSONSimDef>(HttpContext.Session.GetString("SimJSON")!, options)!;
            SimInit(jsonObject);
        }
        else
        {
            SimInit();
        }
        if (Turn < SimHistory.TurnLogs.Count - 1)
        {
            Turn++;
            HttpContext.Session.SetInt32("Turn", Turn);
            CurrentLog = SimHistory.TurnLogs[Turn];
        }
    }

    public void OnPostPrevTurn()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (SimHistory == null)
        {
            if (HttpContext.Session.GetString("SimJSON") != null)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.Preserve,
                    PropertyNameCaseInsensitive = true
                };

                JSONSimDef jsonObject = JsonSerializer.Deserialize<JSONSimDef>(HttpContext.Session.GetString("SimJSON")!, options)!;
                SimInit(jsonObject);
            }
            else
            {
                SimInit();
            }
        }
        if (Turn > 0)
        {
            Turn--;
            HttpContext.Session.SetInt32("Turn", Turn);
            CurrentLog = SimHistory.TurnLogs[Turn];
        }
    }

    public void OnPostSimUpload()
    {
        HttpContext.Session.SetInt32("Turn", 0);
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        };

        //if (SimHistory == null)
        //{
            //SimInit();
        //}
        if (File != null && File.Length > 0)
        {
            using (var stream = new MemoryStream())
            {
                File.CopyToAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();
                    HttpContext.Session.SetString("SimJSON", jsonString);
                    try
                    {
                        JSONSimDef jsonObject = JsonSerializer.Deserialize<JSONSimDef>(jsonString, options)!;
                        SimInit(jsonObject);
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"B³¹d deserializacji: {ex.Message}");
                    }
                }
            }
        }
    }
}
