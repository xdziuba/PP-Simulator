namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string movementString)
    {
        List<Direction> directions = new List<Direction>();

        foreach (char c in movementString.ToUpper())
        {
            switch (c)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
            }
        }

        return directions.ToArray();
    }
}