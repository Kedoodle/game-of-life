namespace GameOfLife
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public States State { get; set; }
    }

    public enum States
    {
        Live,
        Dead
    }
}