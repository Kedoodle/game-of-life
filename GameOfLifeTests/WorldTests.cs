using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldShould
    {
        private readonly World _world;
        
        public WorldShould()
        {
            _world = new World(5, 5);
            _world.GetCell(2, 3).ToggleState();
            _world.GetCell(3, 3).ToggleState();
            _world.GetCell(4, 3).ToggleState();
        }
        
        [Fact]
        public void HaveCellsProperty()
        {
            var expected = typeof(List<Cell>);
            var actual = _world.Cells.GetType();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GenerateDeadCellsToPopulateCellsProperty()
        {
            const int expected = 25;
            var actual = _world.Cells.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakeCoordinatesAndReturnCell()
        {
            var cell = _world.GetCell(1, 2);
            const int expectedX = 1;
            const int expectedY = 2;
            var actualX = cell.X;
            var actualY = cell.Y;
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }

        
    }
}