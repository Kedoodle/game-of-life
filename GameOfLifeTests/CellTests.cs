using System;
using Xunit;

namespace GameOfLifeTests
{
    public class CellShould
    {
        [Fact]
        public void ReturnCellXLocation()
        {
            Cell cell = new Cell(1, 2);
            const int expected = 1;
            var actual = cell.X;
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ReturnCellYLocation()
        {
            Cell cell = new Cell(1, 2);
            const int expected = 1;
            var actual = cell.X;
            Assert.Equal(expected, actual);
        }
    }
}