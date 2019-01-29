using System;
using System.Threading;
using GameOfLifeTests;
using static GameOfLife.Controller;

namespace GameOfLife
{
    public class Game
    {
        private readonly IWorldRenderer _worldRenderer;
        private WorldEvaluator _worldEvaluator;

        public Game(IWorldRenderer worldRenderer)
        {
            _worldRenderer = worldRenderer;
        }

        private World World { get; set; }

        public void Initialise()
        {
            InitialiseWorld();
            SetInitialWorldState();
            _worldEvaluator = new WorldEvaluator(World);
        }

        public void Start()
        {
            var generation = 0;
            var input = GetInput(
                "The Game of Life has started! Press enter to move to the next generation, enter 'a' to automatically move through generations, or enter 'q' to quit: ");
            var autoGenerate = input == "a";
            while (true)
            {
                _worldEvaluator.NextGeneration();
                Console.WriteLine($"Generation: {++generation}");
                _worldRenderer.DisplayWorld(World);
                if (autoGenerate)
                    Thread.Sleep(1000);
                else
                    GetInput(
                        "Press enter to move to the next generation, or enter 'q' to quit: ");
            }
        }

        private void SetInitialWorldState()
        {
            var shouldStart = false;
            while (!shouldStart)
            {
                var input = GetInput(
                    "Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");
                while (input != "s" && input != "start" && !IsValidInput(input, ','))
                    input = GetInput(
                        "Invalid input! Enter cell coordinates '<x>,<y>' to toggle initial state, 's' to start, or 'q' to quit: ");
                if (input == "s" || input == "start")
                {
                    shouldStart = true;
                }
                else
                {
                    var coordinates = GetCoordinates(input);
                    var cell = World.GetCell(coordinates.x, coordinates.y);
                    if (cell != null)
                        cell.ToggleState();
                    else
                        Console.Write("No such cell exists! ");
                }

                _worldRenderer.DisplayWorld(World);
            }
        }

        private void InitialiseWorld() // todo sequential methods
        {
            var input = GetInput("Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            while (!IsValidInput(input, 'x'))
                input = GetInput(
                    "Invalid input! Enter desired world dimensions '<width>x<height>' or 'q' to quit: ");
            var dimensions = GetDimensions(input);
            World = new World(dimensions.width, dimensions.height);
            _worldRenderer.DisplayWorld(World);
        }
    }
}