using System;
using GameOfLifeTests;

namespace GameOfLife
{
    public class Game
    {
        private WorldEvaluator _worldEvaluator;
        private readonly IWorldRenderer _worldRenderer;

        private World World { get; set; }

        public Game(IWorldRenderer worldRenderer)
        {
            _worldRenderer = worldRenderer;
        }
        
        public void Initialise()
        {
            InitialiseWorld();
            SetInitialWorldState();
            _worldEvaluator = new WorldEvaluator(World);
        }

        public void Start()
        {
            var generation = 0;
            Controller.GetInput(
                "The Game of Life has started! Press enter to move to the next generation, or enter 'q' to quit: ");
            while (true)
            {
                _worldEvaluator.NextGeneration();
                Console.WriteLine($"Generation: {++generation}");
                _worldRenderer.DisplayWorld(World);
                Controller.GetInput( // todo either by pressing enter OR because the user pressed 'A', so skip this
                    "Press enter to move to the next generation, or enter 'q' to quit: ");
            }
        }

        private void SetInitialWorldState()
        {
            while (true) // todo add some breaking conditon here
            {
                var input = Controller.GetInput(
                    "Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");
                while (input != "s" && input != "start" && !Controller.isValidInput(input, ','))
                    input = Controller.GetInput(
                        "Invalid input! Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");

                if (input == "s" || input == "start") break; // todo Set the breaking condition i.e. "isStarted???"
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

                _worldRenderer.DisplayWorld(World);
            }
        }

        private void InitialiseWorld() // todo sequential methods
        {
            var input = Controller.GetInput("Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            while (!Controller.isValidInput(input, 'x'))
                input = Controller.GetInput(
                    "Invalid input! Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            var width = Controller.GetFirstParameter(input, 'x');
            var height = Controller.GetSecondParameter(input, 'x');
            World = new World(width, height);
            _worldRenderer.DisplayWorld(World);
        }
    }
}