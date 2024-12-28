namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }

    public static void Lab5a()
    {
        Rectangle rect1 = new Rectangle(2, 3, 5, 7);
        Console.WriteLine("Prostokat 1: " + rect1);

        Rectangle rect2 = new Rectangle(7, 5, 3, 2);
        Console.WriteLine("Prostokat 2: " + rect2);

        Point p1 = new Point(1, 1);
        Point p2 = new Point(4, 4);
        Rectangle rect3 = new Rectangle(p1, p2);
        Console.WriteLine("Prostokat 3: " + rect3);

        try
        {
            Rectangle rect4 = new Rectangle(2, 2, 2, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Point testPoint1 = new Point(3, 4);
        Point testPoint2 = new Point(6, 8);
        Console.WriteLine(rect1.Contains(testPoint1));
        Console.WriteLine(rect1.Contains(testPoint2));

    }
}
