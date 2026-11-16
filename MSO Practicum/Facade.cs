using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace MSO_Practicum
{
    public class Facade
    {
        private Interpreter interpreter;
        private Grid grid;

        public string Run(string inputText)
        {
            List<Command> commands = InterpretInput(inputText);
            List<String> output = grid.ExecuteCommands(commands);
            return String.Join(", ", output);
        }

        public string Metrics(string inputText)
        {
            List<Command> commands = InterpretInput(inputText);
            List<int> output = interpreter.GetMetrics(commands);
            return "Line Count: " + output[0] + ", Max repeat depth: " + output[1] + ", Amount of repeats: " + output[3];
        }

        private List<Command> InterpretInput(string inputText)
        {
            List<String> lines = inputText.Split("\n").ToList();
            return interpreter.InterpretLines(lines);
        }
    }
}