using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CellShould
    {
        [Fact]
        public void HaveXLocationProperty()
        {
            var cell = new Cell(1, 2);
            const int expected = 1;
            var actual = cell.X;
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void HaveYLocationProperty()
        {
            var cell = new Cell(1, 2);
            const int expected = 2;
            var actual = cell.Y;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HaveStateProperty()
        {
            var cell = new Cell(1, 2) {State = States.Live};
            const States expected = States.Live;
            var actual = cell.State;
            Assert.Equal(expected, actual);
        }

    }
}