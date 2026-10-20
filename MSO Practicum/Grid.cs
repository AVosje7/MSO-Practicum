using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace MSOPracticum
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

    #if DEBUG
    #region Tests
    public class GridTests
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
    #endregion
    #endif
}