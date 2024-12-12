namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }
        else
        {
            return value;
        }
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        string outputString = value;

        if (outputString.Length > max)
        {
            outputString = outputString.Substring(0, max).TrimEnd();
        }

        outputString = outputString.Trim();

        if (outputString.Length < min)
        {
            outputString = outputString.PadRight(3, placeholder);
        }

        if (char.IsLower(outputString[0]))
        {
            outputString = char.ToUpper(outputString[0]) + outputString.Substring(1);
        }
        return outputString;    
    }
}
