
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Xunit;

namespace MSO_Practicum.Test.Commands
{
    public class CRepeatUntilTest
    {
        private static Character Start() =>
            new Character(new Grid(), Direction.East, new Point(0, 0));

        [Fact]
        public void Run_RepeatsTheBodyWhileConditionIsTrue()
        {
            var c = Start();
            var repeat = new CRepeatUntil(new WallCondition());
            repeat.AddCommand(new CMove(1));

            repeat.Run(c);

            Assert.Equal(new Point(0, 0), c.position);
        }

        [Fact]
        public void Run_NestedRepeats_ExecutesInnerRepeat()
        {
            var c = Start();
            var inner = new CRepeat(3);
            inner.AddCommand(new CMove(1));

            var outer = new CRepeatUntil(new EdgeCondition());
            outer.AddCommand(inner);

            outer.Run(c);

            Assert.Equal(new Point(0, 0), c.position);
        }


        [Fact]
        public void GetCount_CountsItselfAndEveryCommand()
        {
            var repeat = new CRepeatUntil(new EdgeCondition());
            repeat.AddCommand(new CMove(1));
            repeat.AddCommand(new CTurn(true));

            Assert.Equal(3, repeat.GetCount());
        }

        [Fact]
        public void CountRepeats_CountsItselfAndEveryNestedRepeat()
        {
            var outer = new CRepeatUntil(new EdgeCondition());
            outer.AddCommand(new CRepeat(1));
            outer.AddCommand(new CRepeatUntil(new EdgeCondition()));
            outer.AddCommand(new CMove(1));

            Assert.Equal(3, outer.CountRepeats());
        }

        [Fact]
        public void ToString_ReturnsCommandsSeparatedByComma()
        {
            var repeat = new CRepeatUntil(new EdgeCondition());
            repeat.AddCommand(new CMove(1));
            repeat.AddCommand(new CTurn(true));

            Assert.Equal("Move 1, Turn right.", repeat.ToString());
        }
    }
}
