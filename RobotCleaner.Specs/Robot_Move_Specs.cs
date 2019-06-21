using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace RobotCleaner.Specs
{
    public class RobotMoveSpecs
    {
        private Robot robot;
        private Mock<IOffice> mockOffice;

        [SetUp]
        public void Setup()
        {
            this.mockOffice = new Mock<IOffice>();
            this.robot = new Robot(this.mockOffice.Object);
        }

        [Test]
        public void Robot_MoveTo_ShouldSetPositionAndVisit()
        {
            this.robot.MoveTo(-5, -16);

            this.robot.X.Should().Be(-5);
            this.robot.Y.Should().Be(-16);

            this.mockOffice.Verify(office => office.Visit(-5, -16), Times.Once);
        }

        [Test]
        public void Robot_MoveToThenMove_ShouldSetPositionAndVisit()
        {
            this.robot.MoveTo(-5, -16);
            this.robot.Move(CardinalDirection.N);

            this.robot.X.Should().Be(-5);
            this.robot.Y.Should().Be(-15);

            this.mockOffice.Verify(office => office.Visit(-5, -16), Times.Once);
            this.mockOffice.Verify(office => office.Visit(-5, -15), Times.Once);
        }

        [Test]
        public void Robot_MoveToThenMoveCount_ShouldSetPositionAndVisit()
        {
            this.robot.MoveTo(-5, -16);
            this.robot.Move(CardinalDirection.N, 3);

            this.robot.X.Should().Be(-5);
            this.robot.Y.Should().Be(-13);

            this.mockOffice.Verify(office => office.Visit(-5, -16), Times.Once);
            this.mockOffice.Verify(office => office.Visit(-5, -15), Times.Once);
            this.mockOffice.Verify(office => office.Visit(-5, -14), Times.Once);
            this.mockOffice.Verify(office => office.Visit(-5, -13), Times.Once);
        }
    }
}
