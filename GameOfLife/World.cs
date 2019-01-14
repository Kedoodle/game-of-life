using System.Collections.Generic;
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
            for (var y = 1; y <= height; y++)
                cells.Add(new Cell(x, y, state));
            return cells;
        }
    }
}