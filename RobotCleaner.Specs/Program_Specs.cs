using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace RobotCleaner.Specs
{
    public class ProgramSpecs
    {
        [SetUp]
        public void Setup()
        {
            this.stringWriter = new StringWriter();
        }

        private StringWriter stringWriter;

        [Test]
        public void Program_SmallCircle()
        {
            var input = "4\n" + "-1 -1\n" + "E 2\n" + "N 2\n" + "W 2\n" + "S 2\n";
            var stringReader = new StringReader(input);

            Program.Main(stringReader, this.stringWriter);
            var output = this.stringWriter.GetStringBuilder().ToString();

            output.Should().Be("=> Cleaned: 8\r\n");
        }

        [Test]
        public void Program_ThereAndBackAgain()
        {
            var input = "2\n" + "0 0\n" + "E 20\n" + "W 20\n";
            var stringReader = new StringReader(input);

            Program.Main(stringReader, this.stringWriter);
            var output = this.stringWriter.GetStringBuilder().ToString();

            output.Should().Be("=> Cleaned: 21\r\n");
        }
    }
}
