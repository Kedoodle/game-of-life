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
            Cells = new List<Cell>();
            for (var x = 1; x <= Width; x++)
            {
                for (var y = 1; y <= Height; y++)
                {
                    Cells.Add(new Cell(x, y));
                }
            }
        }

        public int Width { get; }
        public int Height { get; }
        public List<Cell> Cells { get; }

        
        
        
    }
}