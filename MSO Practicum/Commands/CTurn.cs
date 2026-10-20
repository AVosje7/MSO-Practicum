using System;
using System.Collections.Generic;

namespace MSOPracticum
{
    public class CTurn : Command
    {
        public bool clockwise { get; private set; }

        public CTurn(bool clockwise)
        {
            this.clockwise = clockwise;
        }

        public void Run(Character character)
        {
            character.Turn(clockwise);
        }

        public override string ToString()
        {
            return $"Turn {(clockwise ? "right" : "left")}";
        }
    }
}