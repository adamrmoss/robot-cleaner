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

            var initialPosition = Regex.Split(input.ReadLine(), @"\s+");
            var initialX = int.Parse(initialPosition[0]);
            var initialY = int.Parse(initialPosition[1]);

            robot.MoveTo(initialX, initialY);

            for (var i = 0; i < numberOfCommands; i++)
            {
                var command = Regex.Split(input.ReadLine(), @"\s+");
                var direction = Enum.Parse<CardinalDirection>(command[0]);
                var distance = int.Parse(command[1]);

                robot.Move(direction, distance);
            }

            output.WriteLine($"=> Cleaned: {office.VisitedLocationsCount}");
        }
    }
}
