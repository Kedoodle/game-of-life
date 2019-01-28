namespace GameOfLife
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var consoleWorldRenderer = new ConsoleWorldRenderer();
            var game = new Game(consoleWorldRenderer);
            game.Initialise();
            game.Start();
        }
    }
}