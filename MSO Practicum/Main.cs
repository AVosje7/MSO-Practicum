using System;
using System.Collections.Generic;

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
}