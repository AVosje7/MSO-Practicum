using System;
using System.Collections.Generic;
using Xunit;
using System.Drawing;

namespace MSOPracticum
{
    public class CMove : Command
    {
        public int amount { get; private set; }

        public CMove(int amount)
        {
            this.amount = amount;
        }

        public void Run(Character character)
        {
            character.Move(amount);
        }

        public override string ToString()
        {
            return $"Move {amount}";
        }
    }

    #if DEBUG
    #region Tests
    public class CMoveTests
    {
        [Fact]
        public void Run_MovesTheCharacterByItsAmount()
        {
            var c = new Character(Direction.East, new Point(0, 0));

            new CMove(4).Run(c);

            Assert.Equal(new Point(4, 0), c.position);
        }

        [Fact]
        public void ToString_DescribesTheMove()
        {
            Assert.Equal("Move 3", new CMove(3).ToString());
        }
    }
    #endregion
    #endif
}