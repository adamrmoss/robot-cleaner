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
        private StringReader stringReader;

        [Test]
        public void Program_NoCommands()
        {
            this.initializeInput("0\n" + "37 42\n");

            var output = this.runAndGetOutput();

            output.Should().Be("=> Cleaned: 1\r\n");
        }

        [Test]
        public void Program_NoMovement()
        {
            this.initializeInput("4\n" + "-1 -1\n" + "E 0\n" + "N 0\n" + "W 0\n" + "S 0\n");

            var output = this.runAndGetOutput();

            output.Should().Be("=> Cleaned: 1\r\n");
        }

        [Test]
        public void Program_SmallCircle()
        {
            this.initializeInput("4\n" + "-1 -1\n" + "E 2\n" + "N 2\n" + "W 2\n" + "S 2\n");

            var output = this.runAndGetOutput();

            output.Should().Be("=> Cleaned: 8\r\n");
        }

        [Test]
        public void Program_ThereAndBackAgain()
        {
            this.initializeInput("2\r\n" + "0 0\r\n" + "E 20\r\n" + "W 20\r\n");

            var output = this.runAndGetOutput();

            output.Should().Be("=> Cleaned: 21\r\n");
        }

        private void initializeInput(string input)
        {
            this.stringReader = new StringReader(input);
        }

        private string runAndGetOutput()
        {
            Program.Main(this.stringReader, this.stringWriter);
            return this.stringWriter.GetStringBuilder().ToString();
        }
    }
}
