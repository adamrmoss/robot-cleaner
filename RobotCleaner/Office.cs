using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public interface IOffice
    {
        int VisitedLocationsCount { get; }
        void Visit(int x, int y);
    }

    public class Office : IOffice
    {
        public Office()
        {
            this.visitedLocations = new HashSet<(int x, int y)>();
        }

        private readonly HashSet<(int x, int y)> visitedLocations;

        public int VisitedLocationsCount => this.visitedLocations.Count;

        public void Visit(int x, int y)
        {
            this.visitedLocations.Add((x, y));
        }
    }
}
