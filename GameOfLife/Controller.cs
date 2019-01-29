using System;
using System.Linq;

namespace GameOfLife
{
    public class Controller // todo Maybe improve this name or extract out into separate things which can be named better
    {
        public static string GetInput(string query)
        {
            Console.Write(query);
            var input = Console.ReadLine().ToLower();
            if (input == "q" || input == "quit" || input == "exit") Environment.Exit(0);
            return input;
        }

        public static bool isValidInput(string input, char separator) // todo input > 0
        {
            if (input.Count(c => c == separator) != 1) return false;
            var index = input.IndexOf(separator);
            return int.TryParse(input.Substring(0, index), out var x) &&
                   int.TryParse(input.Substring(index + 1), out var y);
        }

        public static Tuple<int, int> GetDimensions(string input)
        {
            return new Tuple<int, int>(GetFirstParameter(input, 'x'), GetSecondParameter(input, 'x'));
        }
        
        public static Tuple<int, int> GetCoordinates(string input)
        {
            return new Tuple<int, int>(GetFirstParameter(input, ','), GetSecondParameter(input, ','));
        }
        
        private static int GetFirstParameter(string input, char separator)
        {
            var index = input.IndexOf(separator);
            return int.Parse(input.Substring(0, index));
        }

        private static int GetSecondParameter(string input, char separator)
        {
            var index = input.IndexOf(separator);
            return int.Parse(input.Substring(index + 1));
        }
    }
}