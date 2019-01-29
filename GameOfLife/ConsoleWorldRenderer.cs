using System;
using System.Text;

namespace GameOfLife
{
    
    public class ConsoleWorldRenderer : IWorldRenderer
    {
 
        public void DisplayWorld(World world)
        {
            Console.Write(GetWorldAsString(world));
        }

        public static string GetWorldAsString(World world)
        {
            var sb = new StringBuilder();
            for (var y = 1; y <= world.Height; y++)
            {
                for (var x = 1; x <= world.Width; x++)
                {
                    var cell = world.GetCell(x, y);
                    var state = cell.State;
                    sb.Append(state == States.Dead ? ". " : "+ ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}