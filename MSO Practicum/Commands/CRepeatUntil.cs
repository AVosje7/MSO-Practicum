using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSO_Practicum
{
    public class CRepeatUntil : Command
    {
        private Condition condition;
        public List<Command> commands { get; private set; }

        public CRepeatUntil(Condition condition)
        {
            this.condition = condition;
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
                if (command is CRepeatUntil cRepeatUntil)
                {
                    int depth = cRepeatUntil.GetDepth();
                    if (depth > maxDepth)
                        maxDepth = depth;
                }
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
                if (c is CRepeatUntil inner)
                    count += inner.CountRepeats();
                if (c is CRepeat innerRepeat)
                    count += innerRepeat.CountRepeats();
            }
            return count;
        }
    }
}