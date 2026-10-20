using System;
using System.Collections.Generic;
using Xunit;
using System.IO;
using System.Drawing;

namespace MSOPracticum
{
    public class Interpreter
    {
        private FileReader fileReader;
        private List<String> lines;
        public List<Command> commands { get; private set; }

        public Interpreter()
        {
            fileReader = new FileReader();
            lines = new List<String>();
            commands = new List<Command>();
        }

        public void LoadFile(String filePath)
        {
            fileReader.LoadFile(filePath);
            lines = fileReader.GetLines();
            commands = InterpretLines(lines);
        }

        public List<int> GetMetrics()
        {
            List<int> metrics = new List<int>();

            int maxDepth = 0;
            int totalRepeats = 0;

            foreach (Command command in commands)
            {
                if (command is CRepeat cRepeat)
                {
                    totalRepeats += cRepeat.CountRepeats();
                    int depth = cRepeat.GetDepth();
                    if (depth > maxDepth)
                        maxDepth = depth;
                }
            }

            metrics.Add(lines.Count);
            metrics.Add(maxDepth);
            metrics.Add(totalRepeats);

            return metrics;
        }

        private List<Command> InterpretLines(List<String> lines)
        {
            List<Command> commands = new List<Command>();
            for (int i = 0; i < lines.Count; i++)
            {
                Command command = InterpretLine(lines[i]);
                if (command != null)
                {
                    commands.Add(command);

                    if (command is CRepeat cRepeat)
                    {
                        while (i + 1 < lines.Count && lines[i + 1].StartsWith("    ")) // 4 spaces for indentation
                        {
                            i++;
                            Command innerCommand = InterpretLine(lines[i]);
                            if (innerCommand != null)
                            {
                                cRepeat.AddCommand(innerCommand);
                            }
                        }
                    }
                }
            }
            return commands;
        }

        private Command InterpretLine(String line)
        {
            String[] parts = line.Trim().Split(' ');
            String commandName = parts[0];
            switch (commandName)
            {
                case "Move":
                    int amount = int.Parse(parts[1]);
                    return new CMove(amount);
                case "Turn":
                    bool clockwise = parts[1] == "right";
                    return new CTurn(clockwise);
                case "Repeat":
                    int times = int.Parse(parts[1]);
                    return new CRepeat(times);
                default:
                    return null;
            }
        }
    }
    
    #if DEBUG
    #region Tests
    public class InterpreterTests : IDisposable
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
            var character = new Character(Direction.East, new Point(0, 0));
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
    #endregion
    #endif
}