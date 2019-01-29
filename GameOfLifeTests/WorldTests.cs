using System.Collections.Generic;
using GameOfLife;
using Xunit;
using static GameOfLife.ConsoleWorldRenderer;

namespace GameOfLifeTests
{
    public class WorldShould
    {
        private World _world;
        
        public WorldShould()
        {
            const string worldString = ". . . . . \n" +
                                       ". . . . . \n" +
                                       ". + + + . \n" +
                                       ". . . . . \n" +
                                       ". . . . . \n";
            _world = new World(worldString);
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
        public void TakeWorldStringAndGenerateCells()
        {
            const string expected = ". . . . . \n" +
                                    ". . . . . \n" +
                                    ". + + + . \n" +
                                    ". . . . . \n" +
                                    ". . . . . \n";
            _world = new World(expected);
            var actual = GetWorldAsString(_world);
            Assert.Equal(expected, actual);
        }

    }
}