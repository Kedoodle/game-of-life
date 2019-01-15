using System;
using System.Collections.Generic;
using System.Text;
using GameOfLifeTests;

namespace GameOfLife
{
    public class WorldRenderer
    {

        public WorldRenderer(World world)
        {
            _world = world;
        }

        private readonly World _world;
        
        public void DisplayWorld()
        {
            Console.Write(GetWorldAsString());
        }

        public IEnumerable<char> GetWorldAsString()
        {
            var sb = new StringBuilder();
            for (var y = 1; y <= _world.Height; y++)
            {
                for (var x = 1; x <= _world.Width; x++)
                {
                    var cell = _world.GetCell(x, y);
                    var state = cell.State;
                    sb.Append(state == States.Dead ? ". " : "+ ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}