using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CellShould
    {
        [Fact]
        public void ReturnCellXLocation()
        {
            var cell = new Cell(1, 2);
            const int expected = 1;
            var actual = cell.X;
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ReturnCellYLocation()
        {
            var cell = new Cell(1, 2);
            const int expected = 2;
            var actual = cell.Y;
            Assert.Equal(expected, actual);
        }
        
        
    }
}