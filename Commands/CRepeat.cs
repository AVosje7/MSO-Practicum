using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands
{
    public class CRepeat
    {
        public int times { get; private set; }
        public List<Command> commands { get; private set; }

        public CRepeat(int times, List<Command> commands)
        {
            this.times = times;
            this.commands = commands;
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