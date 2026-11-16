using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Xunit;

namespace MSO_Practicum.Test.Commands
{
    public class CMoveTest
    {
        [Fact]
        public void Run_MovesTheCharacterByItsAmount()
        {
            var c = new Character(new Grid(), Direction.East, new Point(0, 0));

            new CMove(4).Run(c);

            Assert.Equal(new Point(4, 0), c.position);
        }

        [Fact]
        public void ToString_DescribesTheMove()
        {
            Assert.Equal("Move 3", new CMove(3).ToString());
        }
    }
}