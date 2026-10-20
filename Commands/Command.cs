using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Character;

namespace Commands
{
    public interface Command
    {
        public Run(Character character);

        public String ToString();
    }
}