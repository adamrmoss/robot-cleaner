using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RobotCleaner
{
    public class Program
    {
        public static void Main()
        {
            Main(Console.In, Console.Out);
        }

        public static void Main(TextReader input, TextWriter output)
        {
            var office = new Office();
            var robot = new Robot(office);

            var numberOfCommands = int.Parse(input.ReadLine());

            var (x, y) = readInitialPosition(input);
            robot.MoveTo(x, y);

            for (var i = 0; i < numberOfCommands; i++)
            {
                var (direction, distance) = readCommand(input);
                robot.Move(direction, distance);
            }

            output.WriteLine($"=> Cleaned: {office.VisitedLocationsCount}");
        }

        private static (int x, int y) readInitialPosition(TextReader input)
        {
            var initialPosition = Regex.Split(input.ReadLine(), @"\s+");
            var x = int.Parse(initialPosition[0]);
            var y = int.Parse(initialPosition[1]);
            return (x, y);
        }

        private static (CardinalDirection direction, int distance) readCommand(TextReader input)
        {
            var command = Regex.Split(input.ReadLine(), @"\s+");
            var direction = Enum.Parse<CardinalDirection>(command[0]);
            var distance = int.Parse(command[1]);
            return (direction, distance);
        }
    }
}
