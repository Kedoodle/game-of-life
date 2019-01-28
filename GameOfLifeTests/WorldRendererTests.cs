using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class ConsoleWorldRendererShould
    {
        public ConsoleWorldRendererShould()
        {
            _world = new World(5, 5);
            _world.GetCell(2, 3).ToggleState();
            _world.GetCell(3, 3).ToggleState();
            _world.GetCell(4, 3).ToggleState();
            _consoleWorldRenderer = new ConsoleWorldRenderer();
        }

        private readonly World _world;
        private readonly ConsoleWorldRenderer _consoleWorldRenderer;

        [Fact]
        public void TakeWorldAndReturnStringRepresentation()
        {
            
            const string expected = ". . . . . \n" +
                                    ". . . . . \n" +
                                    ". + + + . \n" +
                                    ". . . . . \n" +
                                    ". . . . . \n";
            var actual = _consoleWorldRenderer.GetWorldAsString(_world);
            Assert.Equal(expected, actual);
        }
    }
}