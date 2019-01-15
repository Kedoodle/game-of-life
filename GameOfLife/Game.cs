using System;
using System.Linq;
using GameOfLifeTests;

namespace GameOfLife
{
    public class Game
    {
        private readonly InputHandler _inputHandler;
        private readonly WorldRenderer _worldRenderer;

        public Game()
        {
            _inputHandler = new InputHandler();
            _worldRenderer = new WorldRenderer();
        }


        private World World { get; set; }

        public void Start()
        {
            InitialiseWorld();
            SetInitialWorldState();
        }

        private void SetInitialWorldState()
        {
            while (true)
            {
                var input = _inputHandler.GetInput(
                    "Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");
                while (input != "s" && input != "start" && !_inputHandler.isValid(input, ','))
                    input = _inputHandler.GetInput(
                        "Invalid input! Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");

                if (input == "s" || input == "start") break;
                var x = _inputHandler.GetFirstParameter(input, ',');
                var y = _inputHandler.GetSecondParameter(input, ',');
                World.GetCell(x, y).ToggleState();
                _worldRenderer.DisplayWorld(World);
            }
        }

        private void InitialiseWorld()
        {
            var input = _inputHandler.GetInput("Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            while (!_inputHandler.isValid(input, 'x'))
                input = _inputHandler.GetInput(
                    "Invalid input! Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            var width = _inputHandler.GetFirstParameter(input, 'x');
            var height = _inputHandler.GetSecondParameter(input, 'x');
            World = new World(width, height);
            _worldRenderer.DisplayWorld(World);
        }
    }

    internal class InputHandler
    {
        public string GetInput(string query)
        {
            Console.Write(query);
            var input = Console.ReadLine().ToLower();
            if (input == "q" || input == "quit" || input == "exit") Environment.Exit(0);
            return input;
        }

        public bool isValid(string input, char separator)
        {
            if (input.Count(c => c == separator) != 1) return false;
            var index = input.IndexOf(separator);
            return int.TryParse(input.Substring(0, index), out var x) &&
                   int.TryParse(input.Substring(index + 1), out var y);
        }

        public int GetFirstParameter(string input, char separator)
        {
            var index = input.IndexOf(separator);
            return int.Parse(input.Substring(0, index));
        }

        public int GetSecondParameter(string input, char separator)
        {
            var index = input.IndexOf(separator);
            return int.Parse(input.Substring(index + 1));
        }
    }

    internal class Input
    {
        public Input(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}