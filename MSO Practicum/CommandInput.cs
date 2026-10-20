using System;
using System.Collections.Generic;
using Xunit;

namespace MSOPracticum
{
    public static class CommandInput
    {
        public static List<String> GetInput()
        {
            Console.WriteLine("Enter example (\"Basic\", \"Advanced\", or \"Expert\") or enter file:");
            String filename = Console.ReadLine();

            if (filename.ToLower() == "exit")
            {
                return new List<String> { "exit" };
            }

            Console.WriteLine("Execute or calculate:");
            String operation = Console.ReadLine();

            return ProcessInput(filename, operation);
        }

        public static List<String> ProcessInput(String filename, String operation)
        {
            List<String> processedInput = new List<String>();

            switch (filename.ToLower())
            {
                case "basic":
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", "Basic.txt"));
                    break;
                case "advanced":
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", "Advanced.txt"));
                    break;
                case "expert":
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", "Expert.txt"));
                    break;
                default:
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", filename + ".txt"));
                    break;
            }

            processedInput.Add(operation.ToLower());

            return processedInput;
        }
    }

    #if DEBUG
    #region Tests
    public class CommandInputTests
    {
        private static string Expected(string file) =>
            Path.Combine(AppContext.BaseDirectory, "Programs", file);

        [Theory]
        [InlineData("basic", "Basic.txt")]
        [InlineData("advanced", "Advanced.txt")]
        [InlineData("expert", "Expert.txt")]
        public void ProcessInput_ExampleName_MapsToProgramFile(string name, string file)
        {
            var result = CommandInput.ProcessInput(name, "execute");
            Assert.Equal(Expected(file), result[0]);
        }

        [Theory]
        [InlineData("BASIC")]
        [InlineData("bAsIc")]
        public void ProcessInput_ExampleName_IsCaseInsensitive(string name)
        {
            var result = CommandInput.ProcessInput(name, "execute");
            Assert.Equal(Expected("Basic.txt"), result[0]);
        }


        [Fact]
        public void ProcessInput_UnknownName_IsTreatedAsFileName()
        {
            var result = CommandInput.ProcessInput("myprogram", "execute");
            Assert.Equal(Expected("myprogram.txt"), result[0]);
        }

        [Theory]
        [InlineData("Execute", "execute")]
        [InlineData("CALCULATE", "calculate")]
        public void ProcessInput_Operation_IsLowercased(string input, string expected)
        {
            var result = CommandInput.ProcessInput("basic", input);
            Assert.Equal(expected, result[1]);
        }

    }
    #endregion
    #endif
}
