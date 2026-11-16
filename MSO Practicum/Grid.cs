using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_Practicum
{
    public class Grid
    {
        public Character character { get; private set; }
        public int size { get; private set; } = 0;
        private Tile[,] walls;

        public Grid()
        {
            character = new Character(this, Direction.East, new Point(0, 0));
            walls = new Tile[0,0];
        }

        public void SetGrid(int size, Tile[,] walls)
        {
            this.size = size;
            this.walls = walls;
        }

        // Executes a list of commands on the player
        public List<String> ExecuteCommands(List<Command> commands)
        {
            var results = new List<String>();
            foreach (Command command in commands)
            {
                command.Run(character);
                results.Add(command.ToString());
            }
            return results;
        }

        // Check if the player is on the edge
        public bool OnEdge()
        {
            if (size == 0)
                return false; // If the grid size is not set, we cannot be on the edge.
            return character.position.X == 0 || character.position.X == size - 1 ||
                   character.position.Y == 0 || character.position.Y == size - 1;
        }

        public bool FacingEdge()
        {
            if (size == 0)
                return false;
            switch (character.direction)
            {
                case Direction.East:
                    return character.position.X + 1 >= size;
                case Direction.South:
                    return character.position.Y + 1 >= size;
                case Direction.West:
                    return character.position.X - 1 <= 0;
                case Direction.North:
                    return character.position.Y - 1 <= 0;
                default:
                    throw new InvalidOperationException("Invalid direction");
            }
        }

        // Check if the player is facing a wall
        public bool FacingWall()
        {
            if (walls.Length == 0)
                return false; // If the walls are not set, we cannot be facing a wall.
            switch (character.direction)
            {
                case Direction.East:
                    return walls[character.position.Y, character.position.X + 1] == Tile.Wall;
                case Direction.South:
                    return walls[character.position.Y + 1, character.position.X] == Tile.Wall;
                case Direction.West:
                    return walls[character.position.Y, character.position.X - 1] == Tile.Wall;
                case Direction.North:
                    return walls[character.position.Y - 1, character.position.X] == Tile.Wall;
                default:
                    throw new InvalidOperationException("Invalid direction");
            }
        }

        public override string ToString()
        {
            return character.ToString();
        }
    }
}