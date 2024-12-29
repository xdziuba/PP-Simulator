using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    // Arrange
    [InlineData(5)]
    [InlineData(20)]
    [InlineData(10)]
    public void Constructor_ShouldCreateMap_WithValidSize(int size)
    {
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.SizeX);
        Assert.Equal(size, map.SizeY);
    }

    [Theory]
    // Arrange
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_ShouldThrow_ArgumentOutOfRangeException_ForInvalidSize(int size)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    // Arrange
    [InlineData(5, 5, true)]
    [InlineData(0, 0, true)]
    [InlineData(-1, 0, false)]
    [InlineData(0, -1, false)]
    [InlineData(21, 0, false)]
    [InlineData(0, 21, false)]
    public void Exist_ShouldReturnCorrectResult(int x, int y, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 10, Direction.Up, 10, 11)]
    [InlineData(19, 19, Direction.Right, 19, 19)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    public void Next_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(startX, startY);
        // Act
        var result = map.Next(point, direction);
        // Assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(10, 10, Direction.Up, 11, 11)]
    [InlineData(19, 19, Direction.Right, 19, 19)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(startX, startY);
        // Act
        var result = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }
}
