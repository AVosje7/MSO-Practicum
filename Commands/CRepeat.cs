using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Character;

namespace Commands
{
    public class CRepeat
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
    }
}