using System.Collections.Generic;
using System.Linq;
using GameOfLife;

namespace GameOfLifeTests
{
    public class World
    {
        
         // todo contstuctor which takes in a predefined world 
        // todo As string + as list of cells and size
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = GenerateCells(Width, Height, States.Dead);
        }

        public World(string worldString)
        {
            
            // todo Creating a world via a string
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