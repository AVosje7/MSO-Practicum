using System;
using System.Collections.Generic;

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
                    totalRepeats++;
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
            String[] parts = line.Split(' ');
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
}