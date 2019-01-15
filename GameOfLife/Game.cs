using System;
using GameOfLifeTests;

namespace GameOfLife
{
    public class Game
    {
        private WorldRenderer _worldRenderer;

        private World World { get; set; }

        public void Initialise()
        {
            InitialiseWorld();
            SetInitialWorldState();
        }

        public void Start()
        {
            var generation = 0;
            Controller.GetInput(
                "The Game of Life has started! Press enter to move to the next generation, or enter 'q' to quit: ");
            while (true)
            {
                World.NextGeneration();
                Console.WriteLine($"Generation: {++generation}");
                _worldRenderer.DisplayWorld();
                Controller.GetInput(
                    "Press enter to move to the next generation, or enter 'q' to quit: ");
            }
        }

        private void SetInitialWorldState()
        {
            while (true)
            {
                var input = Controller.GetInput(
                    "Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");
                while (input != "s" && input != "start" && !Controller.isValidInput(input, ','))
                    input = Controller.GetInput(
                        "Invalid input! Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");

                if (input == "s" || input == "start") break;
                var x = Controller.GetFirstParameter(input, ',');
                var y = Controller.GetSecondParameter(input, ',');
                var cell = World.GetCell(x, y);
                if (cell != null)
                {
                    cell.ToggleState();
                }
                else
                {
                    Console.Write("No such cell exists! ");
                    continue;
                }

                _worldRenderer.DisplayWorld();
            }
        }

        private void InitialiseWorld()
        {
            var input = Controller.GetInput("Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            while (!Controller.isValidInput(input, 'x'))
                input = Controller.GetInput(
                    "Invalid input! Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            var width = Controller.GetFirstParameter(input, 'x');
            var height = Controller.GetSecondParameter(input, 'x');
            World = new World(width, height);
            _worldRenderer = new WorldRenderer(World);
            _worldRenderer.DisplayWorld();
        }
    }
}