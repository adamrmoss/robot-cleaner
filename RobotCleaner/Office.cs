using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public class Office
    {
        public Office()
        {
            this.visitedLocations = new HashSet<(int x, int y)>();
        }

        public void Visit(int x, int y)
        {
            this.visitedLocations.Add((x, y));
        }

        public int VisitedLocationsCount => this.visitedLocations.Count;

        private readonly HashSet<(int x, int y)> visitedLocations;
    }
}
