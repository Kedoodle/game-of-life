using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldShould
    {
        private readonly World World;
        
        public WorldShould()
        {
            World = new World(5, 5);
            World.GetCell(2, 3).ToggleState();
            World.GetCell(3, 3).ToggleState();
            World.GetCell(4, 3).ToggleState();
        }
        
        [Fact]
        public void HaveCellsProperty()
        {
            var expected = typeof(List<Cell>);
            var actual = World.Cells.GetType();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GenerateDeadCellsToPopulateCellsProperty()
        {
            const int expected = 25;
            var actual = World.Cells.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakeCoordinatesAndReturnCell()
        {
            var cell = World.GetCell(1, 2);
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
            var cell = World.GetCell(3, 3);
            var expected = new List<Cell>
            {
                World.GetCell(2, 2), World.GetCell(3, 2), World.GetCell(4, 2),
                World.GetCell(2, 3), World.GetCell(4, 3),
                World.GetCell(2, 4), World.GetCell(3, 4), World.GetCell(4, 4)
            };
            var actual = World.GetNeighbouringCells(cell);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void TakeCellAndReturnNumberOfLiveNeighbouringCells()
        { 
            var cell = World.GetCell(3, 3);
            const int expected = 2;
            var actual = World.GetNumberOfLiveNeighbours(cell);
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
            var cell = World.GetCell(x, y);
            var expected = shouldToggle;
            var actual = World.ShouldCellToggle(cell);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void DetermineCellsToToggleForNextGeneration()
        {
            var expected = new List<Cell>
            {
                World.GetCell(2, 3),
                World.GetCell(3, 2),
                World.GetCell(3, 4),
                World.GetCell(4, 3)
            };
            var actual = World.GetCellsToToggle();
            Assert.Equal(expected, actual);
        }
    }
}