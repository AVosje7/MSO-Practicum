using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Xunit;

namespace MSO_Practicum.Test
{
    public class InterpreterTest : IDisposable
    {
        private readonly List<string> tempFiles = new List<string>();

        private Interpreter Load(string content)
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");
            File.WriteAllText(path, content);
            tempFiles.Add(path);

            var interpreter = new Interpreter();
            interpreter.LoadFile(path);
            return interpreter;
        }

        private static Character RunAll(Interpreter interpreter)
        {
            var character = new Character(new Grid(), Direction.East, new Point(0, 0));
            foreach (Command command in interpreter.commands)
                command.Run(character);
            return character;
        }

        public void Dispose()
        {
            foreach (string path in tempFiles)
                if (File.Exists(path)) File.Delete(path);
        }

        [Fact]
        public void LoadFile_SpecExample_EndsAtTwoOne()
        {
            var c = RunAll(Load("Move 1\nTurn right\nMove 1\nTurn left\nMove 1"));
            Assert.Equal(new Point(2, 1), c.position);
        }

        [Fact]
        public void LoadFile_UnknownLine_IsIgnored()
        {
            var interpreter = Load("Move 1\nJump 3\nMove 1");
            Assert.Equal(2, interpreter.commands.Count);
        }

        [Fact]
        public void LoadFile_Repeat_RunsIndentedBodyTheGivenNumberOfTimes()
        {
            var c = RunAll(Load("Repeat 3\n    Move 1"));
            Assert.Equal(new Point(3, 0), c.position);
        }

        [Fact]
        public void LoadFile_CommandAfterRepeatBody_IsNotPartOfTheRepeat()
        {
            var c = RunAll(Load("Repeat 2\n    Move 1\nMove 5"));
            Assert.Equal(new Point(7, 0), c.position);   // 2 + 5
        }

        [Fact]
        public void LoadFile_NestedRepeat_MultipliesTheCounts()
        {
            var c = RunAll(Load("Repeat 2\n    Repeat 3\n        Move 1"));
            Assert.Equal(new Point(6, 0), c.position);
        }

        [Fact]
        public void GetMetrics_SingleRepeat()
        {
            var metrics = Load("Repeat 2\n    Move 1").GetMetrics();
            Assert.Equal(new List<int> { 2, 1, 1 }, metrics);
        }

        [Fact]
        public void GetMetrics_NestedRepeat_CountsBothRepeatsAndDepthTwo()
        {
            var metrics = Load("Repeat 2\n    Repeat 3\n        Move 1").GetMetrics();
            Assert.Equal(new List<int> { 3, 2, 2 }, metrics);
        }
    }
}