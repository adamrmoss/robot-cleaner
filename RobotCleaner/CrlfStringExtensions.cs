using System;

namespace RobotCleaner
{
    public static class CrlfStringExtensions
    {
        public static string NormalizeCrlf(this string input)
            => input.Replace("\r", "");
    }
}
