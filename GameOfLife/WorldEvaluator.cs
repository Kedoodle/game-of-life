using System.Collections.Generic;
using System.Linq;
using GameOfLife;

namespace GameOfLifeTests
{
    public class WorldEvaluator
    {
        private readonly World _world;

        public WorldEvaluator(World world)
        {
            _world = world;
        }
        
        public IEnumerable<Cell> GetNeighbouringCells(Cell cell)
        {
            var leftX = cell.X == 1 ? _world.Width : cell.X - 1;
            var rightX = cell.X == _world.Width ? 1 : cell.X + 1;
            var topY = cell.Y == 1 ? _world.Height : cell.Y - 1;
            var bottomY = cell.Y == _world.Height ? 1 : cell.Y + 1;
            var neighbours = new List<Cell>
            {
                _world.GetCell(leftX, topY), _world.GetCell(cell.X, topY), _world.GetCell(rightX, topY),
                _world.GetCell(leftX, cell.Y), _world.GetCell(rightX, cell.Y),
                _world.GetCell(leftX, bottomY), _world.GetCell(cell.X, bottomY), _world.GetCell(rightX, bottomY)
            };
            return neighbours;
        }

        public int GetNumberOfLiveNeighbours(Cell cell)
        {
            var neighbours = GetNeighbouringCells(cell);
            return neighbours.Count(c => c.State == States.Live);
        }

        public bool ShouldCellToggle(Cell cell)
        {
            var liveNeighbours = GetNumberOfLiveNeighbours(cell);
            return cell.State == States.Live ? liveNeighbours != 2 && liveNeighbours != 3 : liveNeighbours == 3;
        }

        public IEnumerable<Cell> GetCellsToToggle()
        {
            return _world.Cells.Where(ShouldCellToggle);
        }

        public void NextGeneration()
        {
            GetCellsToToggle().ToList().ForEach(cell => cell.ToggleState());
        }
    }
}