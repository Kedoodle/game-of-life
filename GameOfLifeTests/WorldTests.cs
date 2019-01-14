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

    public class World
    {
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new List<Cell>();
        }

        public int Width { get; }
        public int Height { get; }
        public List<Cell> Cells { get; }
    }
}