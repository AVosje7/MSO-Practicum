using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace MSO_Practicum.Exceptions
{
    public class ObstacleException : Exception
    {
        public Point position {get;}
        public ObstacleException(String message, Point position) : base(message)
        {
            this.position = position;
        }
    }
}