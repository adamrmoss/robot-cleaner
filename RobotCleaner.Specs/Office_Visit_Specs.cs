using System;
using FluentAssertions;
using NUnit.Framework;

namespace RobotCleaner.Specs
{
    public class OfficeVisitSpecs
    {
        private Office office;

        [SetUp]
        public void Setup()
        {
            this.office = new Office();
            this.office.VisitedLocationsCount.Should().Be(0);
        }

        [Test]
        public void Office_Visit_CountsFirst()
        {
            this.office.Visit(5, 12);
            this.office.VisitedLocationsCount.Should().Be(1);
        }

        [Test]
        public void Office_Visit_CountsDistinct()
        {
            this.office.Visit(8, 10);
            this.office.Visit(10, 8);
            this.office.VisitedLocationsCount.Should().Be(2);
        }

        [Test]
        public void Office_Visit_DoesNotCountDuplicates()
        {
            this.office.Visit(8, 10);
            this.office.Visit(8, 10);
            this.office.VisitedLocationsCount.Should().Be(1);
        }
    }
}
