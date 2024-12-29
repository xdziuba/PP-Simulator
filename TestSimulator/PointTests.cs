using Simulator;

namespace TestSimulator;
public class PointTests
{
    [Fact]
    public void Constructor_ShouldCreateCorrectPoint()
    {
        // Arrange
        var point = new Point(3, 5);
        // Acet & Assert
        Assert.Equal(3, point.X);
        Assert.Equal(5, point.Y);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Arrange
        var point = new Point(7, -2);
        // Act
        var result = point.ToString();
        // Assert
        Assert.Equal("(7, -2)", result);
    }

    [Theory]
    [InlineData(Direction.Left, -1, 0)]
    [InlineData(Direction.Right, 1, 0)]
    [InlineData(Direction.Up, 0, 1)]
    [InlineData(Direction.Down, 0, -1)]
    public void Next_ShouldReturnCorrectPoint(Direction direction, int dx, int dy)
    {
        // Arrange
        var point = new Point(3, 3);
        // Act
        var result = point.Next(direction);
        // Assert
        Assert.Equal(3 + dx, result.X);
        Assert.Equal(3 + dy, result.Y);
    }

    [Theory]
    [InlineData(Direction.Left, -1, 1)]
    [InlineData(Direction.Right, 1, -1)]
    [InlineData(Direction.Up, 1, 1)]
    [InlineData(Direction.Down, -1, -1)]
    public void NextDiagonal_ShouldReturnCorrectPoint(Direction direction, int dx, int dy)
    {
        // Arrange
        var point = new Point(3, 3);
        // Act
        var result = point.NextDiagonal(direction);
        // Assert
        Assert.Equal(3 + dx, result.X);
        Assert.Equal(3 + dy, result.Y);
    }
}

