using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GameOfLife;

namespace GameOfLifeTests
{
    public class World
    {
        
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = GenerateCells(Width, Height, States.Dead);
        }

        public World(string worldString)
        {
            Width = worldString.IndexOf("\n", StringComparison.Ordinal) / 2;
            Height = Regex.Matches(worldString, "\n").Count;
            Cells = new List<Cell>();
            for (var x = 1; x <= Width; x++)
            {
                for (var y = 1; y <= Height; y++)
                {
                    Cells.Add(new Cell(x, y, worldString.Substring((2*Width+1) * (y-1) + 2*(x-1), 1) == "." ? States.Dead : States.Live));
                }
            }
        }

        public int Width { get; }
        public int Height { get; }
        public List<Cell> Cells { get; }

        private static List<Cell> GenerateCells(int width, int height, States state)
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
        
    }
}