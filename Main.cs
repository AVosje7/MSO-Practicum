using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interpreter;
using CommandIO;
using Grid;

namespace Main
{
    public class Main
    {
        private interpreter interpreter;
        private Grid grid;

        public Main(String[] args)
        {
            interpreter = new interpreter();
            grid = new Grid();
            
            bool exit = false;
            while (!exit)
            {
                exit = Run();
            }            
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

        public 

        public void LoadFile(String filePath)
        {
            interpreter.LoadFile(filePath);
        }

        public List<String> ExecuteCommands()
        {
            grid.executeCommands(interpreter.commands);
        }

        public List<int> CalculateMetrics()
        {
            return interpreter.GetMetrics();
        }

        public void WriteSteps(list<String> steps, String endState)
        {
            CommandOutput.WriteSteps(steps, endState);
        }

        public void WriteMetrics(List<int> metrics)
        {
            CommandOutput.WriteMetrics(metrics);
        }
    }
}