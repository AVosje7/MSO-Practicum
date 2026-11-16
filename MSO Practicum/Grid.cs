using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSO_Practicum
{
    public class Grid
    {
        private GridReader gridReader;
        public Character character { get; private set; }
        public int size { get; private set; } = 0;
        private Tile[,] walls;
        private readonly List<Point> movementPath = new List<Point>();

        public Grid()
        {
            character = new Character(this, Direction.East, new Point(0, 0));
            size = 5;
            walls = new Tile[size, size];
            gridReader = new GridReader();
        }

        public void ReadGrid(String filePath)
        {
            gridReader.LoadFile(filePath);
            walls = gridReader.GetGrid();
            size = walls.GetLength(0);
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

        public void ResetCharacter()
        {
            character = new Character(this, Direction.East, new Point(0, 0));
            movementPath.Clear();
            movementPath.Add(character.position);
        }

        public void StartPath()
        {
            movementPath.Clear();
            movementPath.Add(character.position);
        }

        internal void RecordPosition(Point position)
        {
            movementPath.Add(position);
        }

        public void Draw(Graphics graphics, Rectangle bounds)
        {
            if (size == 0)
                return;

            int cellSize = Math.Min(bounds.Width / size, bounds.Height / size);
            if (cellSize == 0)
                return;

            int left = bounds.Left + (bounds.Width - size * cellSize) / 2;
            int top = bounds.Top + (bounds.Height - size * cellSize) / 2;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    var cell = new Rectangle(left + x * cellSize, top + y * cellSize, cellSize, cellSize);
                    Brush fill = walls[y, x] == Tile.Wall ? Brushes.DimGray
                               : walls[y, x] == Tile.Goal ? Brushes.LightGreen
                               : Brushes.White;

                    graphics.FillRectangle(fill, cell);
                    graphics.DrawRectangle(Pens.Black, cell);
                }
            }

            if (movementPath.Count > 1)
            {
                Point[] pathPoints = new Point[movementPath.Count];
                for (int i = 0; i < movementPath.Count; i++)
                {
                    Point position = movementPath[i];
                    pathPoints[i] = new Point(
                        left + position.X * cellSize + cellSize / 2,
                        top + position.Y * cellSize + cellSize / 2);
                }

                using (Pen pathPen = new Pen(Color.Red, Math.Max(2f, cellSize / 10f)))
                {
                    graphics.DrawLines(pathPen, pathPoints);
                }
            }

            int padding = cellSize / 4;
            var characterCell = new Rectangle(
                left + character.position.X * cellSize + padding,
                top + character.position.Y * cellSize + padding,
                cellSize - 2 * padding,
                cellSize - 2 * padding);

            graphics.FillEllipse(Brushes.DodgerBlue, characterCell);
        }

        public override string ToString()
        {
            return character.ToString();
        }
    }
}