using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldRendererShould
    {
        public WorldRendererShould()
        {
            _world = new World(5, 5);
            _world.GetCell(2, 3).ToggleState();
            _world.GetCell(3, 3).ToggleState();
            _world.GetCell(4, 3).ToggleState();
            _worldRenderer = new WorldRenderer(_world);
        }

        private readonly World _world;
        private readonly WorldRenderer _worldRenderer;

        [Fact]
        public void TakeWorldAndReturnStringRepresentation()
        {
            
            var expected = ". . . . . \n" +
                           ". . . . . \n" +
                           ". + + + . \n" +
                           ". . . . . \n" +
                           ". . . . . \n";
            var actual = _worldRenderer.GetWorldAsString();
            Assert.Equal(expected, actual);
        }
    }
}