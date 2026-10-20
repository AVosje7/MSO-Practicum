using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Character
{
    public class Character
    {
        public Direction direction { get; private set; }
        public Point position { get; private set; }

        public Character(Direction direction, Point position)
        {
            this.direction = direction;
            this.position = position;
        }

        public void Move(int amount)
        {
            switch (direction)
            {
                case Direction.East:
                    position.X += amount;
                    break;
                case Direction.South:
                    position.Y += amount;
                    break;
                case Direction.West:
                    position.X -= amount;
                    break;
                case Direction.North:
                    position.Y -= amount;
                    break;
            }
        }

        public void Turn(bool clockwise)
        {
            if (clockwise)
            {
                direction = (Direction)(((int)direction + 1) % 4);
            }
            else
            {
                direction = (Direction)(((int)direction + 3) % 4);
            }
        }

        public override string ToString()
        {
            return $"({position.X}, {position.Y}) facing {direction}";
        }
    }
}