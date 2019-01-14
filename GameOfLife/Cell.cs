namespace GameOfLife
{
    public class Cell
    {
        public Cell(int x, int y, States state)
        {
            X = x;
            Y = y;
            State = state;
        }

        public int X { get; }
        public int Y { get; }
        public States State { get; set; }

        public void ToggleState()
        {
            State = State == States.Dead ? States.Live : States.Dead;
        }
    }

    public enum States
    {
        Live,
        Dead
    }
}