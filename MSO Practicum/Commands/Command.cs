using System;
using System.Collections.Generic;

namespace MSOPracticum
{
    public interface Command
    {
        public void Run(Character character);

        public String ToString();
    }
}