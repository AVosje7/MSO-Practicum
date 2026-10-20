using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace MSOPracticum
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
            }
            return count;
        }
    }
    #if DEBUG
    #region Tests
    public class CRepeatTests
    {
        private static Character Start() =>
            new Character(Direction.East, new Point(0, 0));



        [Fact]
        public void Run_RepeatsTheBodyTheGivenNumberOfTimes()
        {
            var c = Start();
            var repeat = new CRepeat(3);
            repeat.AddCommand(new CMove(1));

            repeat.Run(c);

            Assert.Equal(new Point(3, 0), c.position);
        }

        [Fact]
        public void Run_RunsTheWholeBodyInOrderOnEachRepetition()
        {
            var c = Start();
            var repeat = new CRepeat(2);
            repeat.AddCommand(new CMove(1));
            repeat.AddCommand(new CTurn(true));

            repeat.Run(c);

            Assert.Equal(new Point(1, 1), c.position);
            Assert.Equal(Direction.West, c.direction);
        }

        [Fact]
        public void Run_NestedRepeats_MultiplyTheCounts()
        {
            var c = Start();
            var inner = new CRepeat(3);
            inner.AddCommand(new CMove(1));
            var outer = new CRepeat(2);
            outer.AddCommand(inner);

            outer.Run(c);

            Assert.Equal(new Point(6, 0), c.position);
        }

        [Fact]
        public void GetDepth_TakesTheDeepestBranch()
        {
            var deep = new CRepeat(1);
            deep.AddCommand(new CRepeat(1));          
            var shallow = new CRepeat(1);             

            var outer = new CRepeat(1);
            outer.AddCommand(shallow);
            outer.AddCommand(deep);

            Assert.Equal(3, outer.GetDepth());
        }

        [Fact]
        public void CountRepeats_CountsItselfAndEveryNestedRepeat()
        {
            var outer = new CRepeat(1);
            outer.AddCommand(new CRepeat(1));
            outer.AddCommand(new CRepeat(1));
            outer.AddCommand(new CMove(1));

            Assert.Equal(3, outer.CountRepeats());
        }
    }
#endregion
#endif
}