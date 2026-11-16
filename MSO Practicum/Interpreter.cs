
namespace MSO_Practicum
{
    public class Interpreter
    {
        private FileReader fileReader;
        public List<String> lines { get; private set; }
        public List<Command> commands { get; private set; }

        public Interpreter()
        {
            fileReader = new FileReader();
            lines = new List<String>();
            commands = new List<Command>();
        }

        // Loads a file from a filepath
        public void LoadFile(String filePath)
        {
            fileReader.LoadFile(filePath);
            lines = fileReader.GetLines();
            commands = InterpretLines(lines);
        }

        // Gets the metrics of the loaded commands
        public List<int> GetMetrics(List<Command> inputCommands)
        {
            List<int> metrics = new List<int>();

            int lineAmount = 0;
            int maxDepth = 0;
            int totalRepeats = 0;

            foreach (Command command in inputCommands)
            {
                lineAmount += command.GetCount();
                if (command is CRepeat cRepeat)
                {
                    totalRepeats += cRepeat.CountRepeats();
                    int depth = cRepeat.GetDepth();
                    if (depth > maxDepth)
                        maxDepth = depth;
                }
                if (command is CRepeatUntil cRepeatUntil)
                {
                    totalRepeats += cRepeatUntil.CountRepeats();
                    int depth = cRepeatUntil.GetDepth();
                    if (depth > maxDepth)
                        maxDepth = depth;
                }
            }

            metrics.Add(lineAmount);
            metrics.Add(maxDepth);
            metrics.Add(totalRepeats);

            return metrics;
        }

        // Transforms the strings into commands for the character
        public List<Command> InterpretLines(List<String> lines)
        {
            List<Command> commands = new List<Command>();
            for (int i = 0; i < lines.Count;)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    i++;
                    continue;
                }
                Command command = InterpretLine(lines[i], lines, i);
                if (command != null)
                {
                    commands.Add(command);
                    i += command.GetCount();
                }
            }
            return commands;
        }

        // Transforms a single string into the fitting command
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
                    currentIndex++;
                    while (currentIndex < lines.Count && IndentationLevel(lines[currentIndex]) > indentationLevel)
                    {
                        Command innerCommand = InterpretLine(lines[currentIndex], lines, currentIndex);
                        if (innerCommand != null)
                        {
                            cRepeat.AddCommand(innerCommand);
                            currentIndex += innerCommand.GetCount();
                        }
                    }
                    return cRepeat;
                case "RepeatUntil":
                    Condition condition = null;
                    if (parts[1].Equals("WallAhead"))
                        condition = new WallCondition();
                    if (parts[1].Equals("GridEdge"))
                        condition = new EdgeCondition();
                    CRepeatUntil cRepeatUntil = new CRepeatUntil(condition);
                    currentIndex++;
                    while (currentIndex < lines.Count && IndentationLevel(lines[currentIndex]) > indentationLevel)
                    {
                        Command innerCommand = InterpretLine(lines[currentIndex], lines, currentIndex);
                        if (innerCommand != null)
                        {
                            cRepeatUntil.AddCommand(innerCommand);
                            currentIndex += innerCommand.GetCount();
                        }
                    }
                    return cRepeatUntil;
                default:
                    return null;
            }
        }

        // Counts the leading spaces
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

        // Counts the indentation level
        private int IndentationLevel(string line)
        {
            int leadingSpaces = CountLeadingSpaces(line);
            return leadingSpaces / 4; // Assuming 4 spaces per indentation level
        }


    }
}