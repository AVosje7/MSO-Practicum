using System;
using System.Collections.Generic;
using System.Drawing;
using MSO_Practicum.Exceptions;

namespace MSO_Practicum
{
    public class Character
    {
        private Grid grid;
        public Direction direction { get; private set; }
        public Point position { get; private set; }

        public Character(Grid grid, Direction direction, Point position)
        {
            this.grid = grid;
            this.direction = direction;
            this.position = position;
        }

        public void Move(int amount)
        {
            if (IsFacingWall())
            {
                throw new ObstacleException("Tried to move into a wall", position);
            }
            if (IsFacingEdge())
            {
                throw new EdgeException("Tried to move off of the edge of the grid", position);
            }
            Point previousPosition = position;
            switch (direction)
            {
                case Direction.East:
                    position = new Point(position.X + amount, position.Y);
                    break;
                case Direction.South:
                    position = new Point(position.X, position.Y + amount);
                    break;
                case Direction.West:
                    position = new Point(position.X - amount, position.Y);
                    break;
                case Direction.North:
                    position = new Point(position.X, position.Y - amount);
                    break;
            }
            grid.RecordPosition(position);
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

        public bool IsAtEdge()
        {
            return grid.OnEdge();
        }

        public bool IsFacingEdge()
        {
            return grid.FacingEdge();
        }

        public bool IsFacingWall()
        {
            return grid.FacingWall();
        }

        public override string ToString()
        {
            return $"({position.X},{position.Y}) facing {direction}";
        }
    }
}