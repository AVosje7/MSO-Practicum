using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Xunit;
using System.Reflection.Metadata.Ecma335;

namespace MSO_Practicum.Test
{
    public class GridTest
    {
        private class StubCommand : Command
        {
            private readonly string name;
            private readonly Action<Character> action;

            public StubCommand(string name, Action<Character> action)
            {
                this.name = name;
                this.action = action;
            }

            public  void Run(Character character) => action(character);
            public int GetCount() => 1;
            public override string ToString() => name;
        }

        [Fact]
        public void ExecuteCommands_RunsCommandsInOrderOnTheCharacter()
        {
            var grid = new Grid();
            var commands = new List<Command>
            {
                new StubCommand("Move 1", c => c.Move(1)),
                new StubCommand("Turn right", c => c.Turn(true)),
                new StubCommand("Move 1", c => c.Move(1)),
                new StubCommand("Turn left", c => c.Turn(false)),
                new StubCommand("Move 1", c => c.Move(1)),
            };

            grid.ExecuteCommands(commands);

            Assert.Equal(new Point(2, 1), grid.character.position);
        }

        [Fact]
        public void ExecuteCommands_ReturnsOneResultPerCommandInOrder()
        {
            var grid = new Grid();
            var commands = new List<Command>
            {
                new StubCommand("first", c => { }),
                new StubCommand("second", c => { }),
                new StubCommand("third", c => { }),
            };

            var results = grid.ExecuteCommands(commands);

            Assert.Equal(new List<string> { "first", "second", "third" }, results);
        }

        [Fact]
        public void ExecuteCommands_EmptyList_ReturnsEmptyAndChangesNothing()
        {
            var grid = new Grid();

            var results = grid.ExecuteCommands(new List<Command>());

            Assert.Empty(results);
            Assert.Equal(new Point(0, 0), grid.character.position);
            Assert.Equal(Direction.East, grid.character.direction);
        }
    }
}