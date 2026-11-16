using System;
using System.Collections.Generic;

namespace MSO_Practicum
{
    public interface Command
    {
        public void Run(Character character);

        public int GetCount();

        public String ToString();
    }
}