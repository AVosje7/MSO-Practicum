using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace MSO_Practicum
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
                Command command = InterpretLine(lines[i], lines, i);
                if (command != null)
                {
                    commands.Add(command);

                    if (command is CRepeat cRepeat)
                    {
                        i += cRepeat.commands.Count(); // Skip the lines of the repeat body
                    }
                }
            }
            return commands;
        }

        private Command InterpretLine(String line, List<String> lines, int currentIndex)
        {
            int indentationLevel = IndentationLevel(line);
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
                    CRepeat cRepeat = new CRepeat(times);
                    while (currentIndex + 1 < lines.Count && IndentationLevel(lines[currentIndex + 1]) > indentationLevel)
                    {
                        currentIndex++;
                        Command innerCommand = InterpretLine(lines[currentIndex], lines, currentIndex);
                        if (innerCommand != null)
                        {
                            cRepeat.AddCommand(innerCommand);

                            if (innerCommand is CRepeat innerRepeat)
                            {
                                currentIndex += innerRepeat.commands.Count(); // Skip the lines of the inner repeat
                            }
                        }
                    }
                    return cRepeat;
                default:
                    return null;
            }
        }

        private int CountLeadingSpaces(string line)
        {
            int count = 0;
            foreach (char c in line)
            {
                if (c == ' ')
                    count++;
                else
                    break;
            }
            return count;
        }

        private int IndentationLevel(string line)
        {
            int leadingSpaces = CountLeadingSpaces(line);
            return leadingSpaces / 4; // Assuming 4 spaces per indentation level
        }


    }
}