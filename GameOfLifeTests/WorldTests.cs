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
    }
}