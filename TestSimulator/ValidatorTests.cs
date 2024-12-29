using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    // Arrange
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-5, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        // Act
        int result = Validator.Limiter(value, min, max);
        // Assert
        Assert.Equal(expected, result);
    }

    // Arrange
    [Theory]
    [InlineData("example", 3, 5, '-', "Examp")]
    [InlineData("ab", 3, 5, '#', "Ab#")]
    [InlineData("test", 2, 10, '.', "Test")]
    [InlineData("  hello world  ", 2, 5, '-', "Hel")]
    [InlineData("a", 3, 5, '_', "A__")]
    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        string result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}
