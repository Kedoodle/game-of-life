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

        [Fact]
        public void TakeCellAndReturnListOfNeighbouringCells()
        {       
            var cell = _world.GetCell(3, 3);
            var expected = new List<Cell>
            {
                _world.GetCell(2, 2), _world.GetCell(3, 2), _world.GetCell(4, 2),
                _world.GetCell(2, 3), _world.GetCell(4, 3),
                _world.GetCell(2, 4), _world.GetCell(3, 4), _world.GetCell(4, 4)
            };
            var actual = _world.GetNeighbouringCells(cell);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void TakeCellAndReturnNumberOfLiveNeighbouringCells()
        { 
            var cell = _world.GetCell(3, 3);
            const int expected = 2;
            var actual = _world.GetNumberOfLiveNeighbours(cell);
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
            var cell = _world.GetCell(x, y);
            var expected = shouldToggle;
            var actual = _world.ShouldCellToggle(cell);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void DetermineCellsToToggleForNextGeneration()
        {
            var expected = new List<Cell>
            {
                _world.GetCell(2, 3),
                _world.GetCell(3, 2),
                _world.GetCell(3, 4),
                _world.GetCell(4, 3)
            };
            var actual = _world.GetCellsToToggle();
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(3, 2, States.Live)]
        [InlineData(2, 3, States.Dead)]
        [InlineData(3, 3, States.Live)]
        [InlineData(4, 3, States.Dead)]
        [InlineData(3, 4, States.Live)]
        public void IterateToNextGenerationWhenNextGenerationIsCalled(int x, int y, States state)
        {
            _world.NextGeneration();
            var cell = _world.GetCell(x, y);
            var expected = state;
            var actual = cell.State;
            Assert.Equal(expected, actual);
        }
    }
}