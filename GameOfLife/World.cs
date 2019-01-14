using System.Collections.Generic;
using System.Linq;
using GameOfLife;

namespace GameOfLifeTests
{
    public class World
    {
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = GenerateCellsList(Width, Height, States.Dead);
        }

        public int Width { get; }
        public int Height { get; }
        public List<Cell> Cells { get; }

        private static List<Cell> GenerateCellsList(int width, int height, States state)
        {
            var cells = new List<Cell>();
            for (var x = 1; x <= width; x++)
            {
                for (var y = 1; y <= height; y++)
                {
                    cells.Add(new Cell(x, y, state));
                }
            }
            return cells;
        }

        public Cell GetCell(int x, int y)
        {
            return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);
        }

        public IEnumerable<Cell> GetNeighbouringCells(Cell cell)
        {
            var leftX = cell.X == 1 ? Width : cell.X - 1;
            var rightX = cell.X == Width ? 1 : cell.X + 1;
            var topY = cell.Y == 1 ? Height : cell.Y - 1;
            var bottomY = cell.Y == Height ? 1 : cell.Y + 1;
            var neighbouringCells = new List<Cell>
            {
                GetCell(leftX, topY), GetCell(cell.X, topY), GetCell(rightX, topY),
                GetCell(leftX, cell.Y), GetCell(rightX, cell.Y),
                GetCell(leftX, bottomY), GetCell(cell.X, bottomY), GetCell(rightX, bottomY)
            };
            return neighbouringCells;
        }
    }
}