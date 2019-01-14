using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldShould
    {
        [Fact]
        public void HaveCellsProperty()
        {
            var world = new World(5, 5);
            var expected = typeof(List<Cell>);
            var actual = world.Cells.GetType();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GenerateDeadCellsToPopulateCellsProperty()
        {
            var world = new World(5, 5);
            const int expected = 25;
            var actual = world.Cells.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakeCoordinatesAndReturnCell()
        {
            var world = new World(5, 5);
            var cell = world.GetCell(1, 2);
            const int expectedX = 1;
            const int expectedY = 2;
            var actualX = cell.X;
            var actualY = cell.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }
    }
}