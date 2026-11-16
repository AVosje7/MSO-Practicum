using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace MSO_Practicum
{
    public class Facade
    {
        private Interpreter interpreter;
        private Grid grid;

        public Facade()
        {
            interpreter = new Interpreter();
            grid = new Grid();
        }

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
            return "Line Count: " + output[0] + ", Max repeat depth: " + output[1] + ", Amount of repeats: " + output[2];
        }

        public string LoadBasicFile() => LoadPresetFile("Basic.txt");
        public string LoadAdvancedFile() => LoadPresetFile("Advanced.txt");
        public string LoadExpertFile() => LoadPresetFile("Expert.txt");

        private string LoadPresetFile(string filePath)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Programs", filePath);
            interpreter.LoadFile(path);
            return string.Join(Environment.NewLine, interpreter.lines);
        }

        public string LoadCustomFile(string filePath)
        {
            interpreter.LoadFile(filePath);
            List<String> lines = interpreter.lines;
            return String.Join(Environment.NewLine, lines);
        }

        public void LoadCustomGrid(string filePath)
        {
            grid.ReadGrid(filePath);
            grid.ResetCharacter();
        }

        public void DrawGrid(Graphics graphics, Rectangle bounds)
        {
            grid.Draw(graphics, bounds);
        }

        public void ResetCharacter()
        {
            grid.ResetCharacter();
        }

        private List<Command> InterpretInput(string inputText)
        {
            List<String> lines = inputText.Split("\n").ToList();
            return interpreter.InterpretLines(lines);
        }
    }
}