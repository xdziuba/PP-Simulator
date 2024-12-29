using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldThrowArgumentException_ForCollinearRectangles()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 5));
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 5, 0));
    }

    [Fact]
    public void Constructor_ShouldCorrectCoordinates_ForUnorderedPoints()
    {
        // Arrange & Act
        var rectangle = new Rectangle(4, 5, 1, 1);
        // Assert
        Assert.Equal(1, rectangle.X1);
        Assert.Equal(1, rectangle.Y1);
        Assert.Equal(4, rectangle.X2);
        Assert.Equal(5, rectangle.Y2);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Arrange
        var rectangle = new Rectangle(1, 2, 3, 4);
        // Act
        var result = rectangle.ToString();
        // Assert
        Assert.Equal("(1, 2):(3, 4)", result);
    }

    [Theory]
    [InlineData(2, 3, true)]
    [InlineData(1, 2, true)]
    [InlineData(0, 0, false)]
    [InlineData(5, 6, false)]
    public void Contains_ShouldReturnCorrectResult(int x, int y, bool expected)
    {
        // Arrange
        var rectangle = new Rectangle(1, 1, 4, 5);
        var point = new Point(x, y);
        // Act
        var result = rectangle.Contains(point);
        // Assert
        Assert.Equal(expected, result);
    }
}
