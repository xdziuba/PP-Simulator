using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class CreatureTests
{
    [Theory]
    [InlineData(Direction.Up, 2, 3)]
    [InlineData(Direction.Right, 3, 2)]
    [InlineData(Direction.Left, 1, 2)]
    [InlineData(Direction.Down, 2, 1)]
    public void CreatureShouldMoveCorrectlyOnAssignedMap(Direction direction, int x, int y)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var creature = new Elf("Elf1");
        creature.AssignMap(map, new Point(2, 2));
        // Act
        creature.Go(direction);
        // Assert
        Assert.Equal(new Point(x, y), creature.CreaturePos);
    }
}