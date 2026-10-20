using System;
using System.Collections.Generic;

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
}