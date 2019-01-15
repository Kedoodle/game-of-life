namespace GameOfLife
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Initialise();
            game.Start();
        }
    }
}