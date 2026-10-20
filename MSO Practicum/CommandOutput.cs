using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MSOPracticum
{
    public static class CommandOutput
    {
        public static void WriteSteps(List<String> steps, String endState)
        {
            Console.WriteLine(FormatSteps(steps));
            Console.WriteLine("End state " + endState + ".");
        }

        public static void WriteMetrics(List<int> metrics)
        {
            Console.WriteLine("Metrics:");
            foreach (int metric in metrics)
            {
                Console.WriteLine(metric);
            }
        }

        private static String FormatSteps(List<String> steps)
        {
            return String.Join(", ", steps);
        }
    }

    #if DEBUG
    #region Tests
    [Collection("Console")]
    public class CommandOutputTests
    {
        private static string Capture(Action action)
        {
            var original = Console.Out;
            try
            {
                var writer = new StringWriter();
                Console.SetOut(writer);
                action();
                return writer.ToString();
            }
            finally
            {
                Console.SetOut(original);
            }
        }

        private static string Lines(params string[] lines) =>
            string.Join(Environment.NewLine, lines) + Environment.NewLine;

        [Fact]
        public void WriteSteps_JoinsStepsAndPrintsEndState()
        {
            var output = Capture(() =>
                CommandOutput.WriteSteps(new List<string> { "Move 1", "Turn right", "Move 1" }, "(1,1) facing South"));

            Assert.Equal(Lines("Move 1, Turn right, Move 1", "End state (1,1) facing South."), output);
        }

        [Fact]
        public void WriteSteps_SingleStep_HasNoSeparator()
        {
            var output = Capture(() =>
                CommandOutput.WriteSteps(new List<string> { "Move 1" }, "(1,0) facing East"));

            Assert.Equal(Lines("Move 1", "End state (1,0) facing East."), output);
        }

        [Fact]
        public void WriteSteps_NoSteps_PrintsEmptyLineThenEndState()
        {
            var output = Capture(() =>
                CommandOutput.WriteSteps(new List<string>(), "(0,0) facing East"));

            Assert.Equal(Lines("", "End state (0,0) facing East."), output);
        }

        [Fact]
        public void WriteMetrics_PrintsHeaderThenEachMetricOnItsOwnLine()
        {
            var output = Capture(() => CommandOutput.WriteMetrics(new List<int> { 5, 2, 3 }));

            Assert.Equal(Lines("Metrics:", "5", "2", "3"), output);
        }

        [Fact]
        public void WriteMetrics_Empty_PrintsOnlyHeader()
        {
            var output = Capture(() => CommandOutput.WriteMetrics(new List<int>()));

            Assert.Equal(Lines("Metrics:"), output);
        }
    }
    #endregion
    #endif

}