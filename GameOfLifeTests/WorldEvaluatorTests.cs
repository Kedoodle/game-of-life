using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldEvaluatorShould
    {
        private readonly World _world;
        private readonly WorldEvaluator _worldEvaluator;

        public WorldEvaluatorShould()
        {
            _world = new World(5, 5);
            _world.GetCell(2, 3).ToggleState();
            _world.GetCell(3, 3).ToggleState();
            _world.GetCell(4, 3).ToggleState();
            _worldEvaluator = new WorldEvaluator(_world);
        }
        
        [Fact]
        public void TakeCellAndReturnListOfNeighbouringCells()
        {       
            var cell = _world.GetCell(1, 1);
            var expected = new List<Cell>
            {
                _world.GetCell(5, 5), _world.GetCell(1, 5), _world.GetCell(2, 5),
                _world.GetCell(5, 1), _world.GetCell(2, 1),
                _world.GetCell(5, 2), _world.GetCell(1, 2), _world.GetCell(2, 2)
            };
            var actual = _worldEvaluator.GetNeighbouringCells(cell);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void TakeCellAndReturnListOfNeighbouringCells2()
        {       
            var cell = _world.GetCell(5, 5);
            var expected = new List<Cell>
            {
                _world.GetCell(4, 4), _world.GetCell(5, 4), _world.GetCell(1, 4),
                _world.GetCell(4, 5), _world.GetCell(1, 5),
                _world.GetCell(4, 1), _world.GetCell(5, 1), _world.GetCell(1, 1)
            };
            var actual = _worldEvaluator.GetNeighbouringCells(cell);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void TakeCellAndReturnNumberOfLiveNeighbouringCells()
        { 
            var cell = _world.GetCell(3, 3);
            const int expected = 2;
            var actual = _worldEvaluator.GetNumberOfLiveNeighbours(cell);
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
            var actual = _worldEvaluator.ShouldCellToggle(cell);
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
            var actual = _worldEvaluator.GetCellsToToggle();
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
            _worldEvaluator.NextGeneration();
            var cell = _world.GetCell(x, y);
            var expected = state;
            var actual = cell.State;
            Assert.Equal(expected, actual);
        }
    }
}