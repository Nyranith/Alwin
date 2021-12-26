using System;
using System.IO;
using Alwin.CLI.Test.Lib;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using Xunit.Abstractions;

namespace Alwin.CLI.Test
{
    public class ProgramTest
    {
        private readonly ITestOutputHelper _output;

        public ProgramTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private static Program CreateProgram(TextWriter outputWriter, TextWriter errorWriter)
        {
            return new Program(outputWriter, errorWriter);
        }

        [Fact]
        public void TestPrintHelp()
        {
            var (_out, error, result) = TextWriterHelper.InvokeWriterAction((@out, err) =>
            {
                var p = CreateProgram(@out, err);
                return p.Run(Array.Empty<string>());
            });

            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            _output.WriteLine(_out);

            _out.Should().NotBeEmpty();
            _out.Should().StartWith("Alwin code toolset");
        }

    }
}
