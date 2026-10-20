using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Character;
using Commands;

namespace Grid
{
    public class Grid
    {
        public Character character { get; private set; }

        public Grid()
        {
            character = new Character(Direction.East, new Point(0, 0));
        }

        public List<String> ExecuteCommands(List<Command> commands)
        {
            var results = new List<String>();
            foreach (Command command in commands)
            {
                command.Run(character);
                results.Add(command.ToString());
            }
            return results;
        }

        public override string ToString()
        {
            return character.ToString();
        }
    }
}