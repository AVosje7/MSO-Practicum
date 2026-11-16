using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_Practicum
{
    public class CRepeat : Command
    {
        public int times { get; private set; }
        public List<Command> commands { get; private set; }

        public CRepeat(int times)
        {
            this.times = times;
            this.commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }

        public int GetDepth()
        {
            int maxDepth = 0;
            foreach (Command command in commands)
            {
                if (command is CRepeat cRepeat)
                {
                    int depth = cRepeat.GetDepth();
                    if (depth > maxDepth)
                        maxDepth = depth;
                }
                if (command is CRepeatUntil cRepeatUntil)
                {
                    int depth = cRepeatUntil.GetDepth();
                    if (depth > maxDepth)
                        maxDepth = depth;
                }
            }
            return maxDepth + 1;
        }

        public void Run(Character character)
        {
            for (int i = 0; i < times; i++)
            {
                foreach (Command command in commands)
                {
                    command.Run(character);
                }
            }
        }

        public override string ToString()
        {
            return string.Join(", ", commands.Select(c => c.ToString())) + ".";
        }

        public int CountRepeats()
        {
            int count = 1;  
            foreach (Command c in commands)
            {
                if (c is CRepeat inner)
                    count += inner.CountRepeats();
                if (c is CRepeatUntil innerUntil)
                    count += innerUntil.CountRepeats();
            }
            return count;
        }
    }
}