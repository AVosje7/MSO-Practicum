using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_Practicum
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

        public int GetCount()
        {
            return 1;
        }

        public override string ToString()
        {
            return $"Move {amount}";
        }
    }
}