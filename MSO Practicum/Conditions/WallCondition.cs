using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSOPracticum
{
    public class WallCondition : Condition
    {
        public bool Check(Character character)
        {
            return character.IsFacingWall();
        }
    }
}