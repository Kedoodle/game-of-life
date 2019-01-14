using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CellShould
    {
        [Fact]
        public void HaveXCoordinateProperty()
        {
            var cell = new Cell(1, 2, States.Live);
            const int expected = 1;
            var actual = cell.X;
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void HaveYCoordinateProperty()
        {
            var cell = new Cell(1, 2, States.Live);
            const int expected = 2;
            var actual = cell.Y;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HaveStateProperty()
        {
            var cell = new Cell(1, 2, States.Live);
            const States expected = States.Live;
            var actual = cell.State;
            Assert.Equal(expected, actual);
        }

    }
}