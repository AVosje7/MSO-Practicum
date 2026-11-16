using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSO_Practicum
{
    public class EdgeCondition : Condition
    {
        public bool Check(Character character)
        {
            return character.IsAtEdge();
        }
    }
}