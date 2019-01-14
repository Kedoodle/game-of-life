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
    }
}