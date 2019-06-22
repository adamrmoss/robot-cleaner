using System;
using System.ComponentModel;

namespace RobotCleaner
{
    public class Robot
    {
        public Robot(IOffice office)
        {
            this.office = office;
        }

        private readonly IOffice office;

        public int X { get; private set; }
        public int Y { get; private set; }

        public void MoveTo(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.visitCurrentPosition();
        }

        public void Move(CardinalDirection direction, int distance)
        {
            for (var i = 0; i < distance; i++)
            {
                this.Move(direction);
            }
        }

        public void Move(CardinalDirection direction)
        {
            switch (direction)
            {
                case CardinalDirection.N:
                    this.Y++;
                    break;

                case CardinalDirection.E:
                    this.X++;
                    break;

                case CardinalDirection.S:
                    this.Y--;
                    break;

                case CardinalDirection.W:
                    this.X--;
                    break;

                default:
                    throw new InvalidEnumArgumentException(nameof(direction), (int) direction, typeof(CardinalDirection));
            }

            this.visitCurrentPosition();
        }

        private void visitCurrentPosition()
        {
            this.office.Visit(this.X, this.Y);
        }
    }
}
