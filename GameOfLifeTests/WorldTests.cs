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

        [Fact]
        public void TakeCellAndReturnListOfNeighbouringCells()
        { 
            var world = new World(5, 5);         
            var cell = world.GetCell(3, 3);
            var expected = new List<Cell>
            {
                world.GetCell(2, 2), world.GetCell(3, 2), world.GetCell(4, 2),
                world.GetCell(2, 3), world.GetCell(4, 3),
                world.GetCell(2, 4), world.GetCell(3, 4), world.GetCell(4, 4)
            };
            var actual = world.GetNeighbouringCells(cell);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void TakeCellAndReturnNumberOfLiveNeighbouringCells()
        { 
            var world = new World(5, 5);
            world.GetCell(2, 2).ToggleState();
            var cell = world.GetCell(3, 3);
            const int expected = 1;
            var actual = world.GetNumberOfLiveNeighbours(cell);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(3, 2, true)]
        [InlineData(2, 3, true)]
        [InlineData(3, 3, false)]
        [InlineData(4, 3, true)]
        [InlineData(3, 4, true)]
        public void TakeCellAndDetermineIfStateShouldToggle(int x, int y, bool shouldToggle)
        {
            var world = new World(5, 5);
            world.GetCell(2, 3).ToggleState();
            world.GetCell(3, 3).ToggleState();
            world.GetCell(4, 3).ToggleState();
            var cell = world.GetCell(x, y);
            var expected = shouldToggle;
            var actual = world.ShouldCellToggle(cell);
            Assert.Equal(expected, actual);

        }
    }
}