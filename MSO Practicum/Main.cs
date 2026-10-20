using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MSOPracticum
{
    public class Program
    {
        private Interpreter interpreter;
        private Grid grid;

        static void Main(String[] args)
        {
            Program program = new Program();

            bool exit = false;
            while (!exit)
            {
                exit = program.Run();
            }            
        }

        public Program()
        {
            interpreter = new Interpreter();
            grid = new Grid();
        }

        public bool Run()
        {
            List<String> input = GetInput();

            if (input[0] == "exit")
            {
                return true;
            }
            
            interpreter.LoadFile(input[0]);

            switch (input[1])
            {
                case "execute":
                    grid = new Grid();
                    List<String> steps = ExecuteCommands();
                    String endState = grid.ToString();
                    WriteSteps(steps, endState);
                    break;
                case "calculate":
                    List<int> metrics = CalculateMetrics();
                    WriteMetrics(metrics);
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please retry.");
                    break;
            }
            return false;
        }

        public List<String> GetInput()
        {
            return CommandInput.GetInput();
        }

        public void LoadFile(String filePath)
        {
            interpreter.LoadFile(filePath);
        }

        public List<String> ExecuteCommands()
        {
            return grid.ExecuteCommands(interpreter.commands);
        }

        public List<int> CalculateMetrics()
        {
            return interpreter.GetMetrics();
        }

        public void WriteSteps(List<String> steps, String endState)
        {
            CommandOutput.WriteSteps(steps, endState);
        }

        public void WriteMetrics(List<int> metrics)
        {
            CommandOutput.WriteMetrics(metrics);
        }
    }

    #if DEBUG
    #region Tests
    [Collection("Console")]
    public class ProgramTests : IDisposable
    {
        private readonly List<string> createdFiles = new List<string>();

        private string CreateProgramFile(string content)
        {
            string name = "test_" + Guid.NewGuid().ToString("N");
            string dir = Path.Combine(AppContext.BaseDirectory, "Programs");
            Directory.CreateDirectory(dir);
            string path = Path.Combine(dir, name + ".txt");
            File.WriteAllText(path, content);
            createdFiles.Add(path);
            return name;
        }
        private static (bool exit, string output) RunWith(Program program, string input)
        {
            var originalIn = Console.In;
            var originalOut = Console.Out;
            try
            {
                var writer = new StringWriter();
                Console.SetIn(new StringReader(input));
                Console.SetOut(writer);
                bool exit = program.Run();
                return (exit, writer.ToString());
            }
            finally
            {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }

        public void Dispose()
        {
            foreach (string path in createdFiles)
                if (File.Exists(path)) File.Delete(path);
        }

        
        [Fact]
        public void Run_Execute_PrintsEndStateAndKeepsRunning()
        {
            string name = CreateProgramFile("Move 1\nTurn right\nMove 1\nTurn left\nMove 1");

            var (exit, output) = RunWith(new Program(), name + "\nexecute\n");

            Assert.False(exit);
            Assert.Contains("End state (2,1) facing East.", output);
        }

        [Fact]
        public void Run_Calculate_PrintsMetrics()
        {
            string name = CreateProgramFile("Repeat 2\n    Move 1");

            var (_, output) = RunWith(new Program(), name + "\ncalculate\n");

            string expected = string.Join(Environment.NewLine, "Metrics:", "2", "1", "1");
            Assert.Contains(expected, output);
        }


        [Fact]
        public void Run_ExecuteTwice_StartsFromTheOriginEachTime()
        {
            string name = CreateProgramFile("Move 1");
            var program = new Program();

            RunWith(program, name + "\nexecute\n");
            var (_, secondOutput) = RunWith(program, name + "\nexecute\n");

            Assert.Contains("End state (1,0) facing East.", secondOutput);
        }
    }
    #endregion
    #endif
}