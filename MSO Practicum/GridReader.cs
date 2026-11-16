using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSO_Practicum
{
    public class GridReader : FileReader
    {
        public Tile[,] GetGrid()
        {
            List<String> lines = GetLines();
            Tile[,] tiles = new Tile[lines.Count, lines[0].Length]; 
            
            for (int i = 0; i < lines.Count(); i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    char c = lines[i][j];
                    if (c == 'o')
                        tiles[i, j] = Tile.Empty;
                    if (c == '+')
                        tiles[i, j] = Tile.Wall;
                    if (c == 'x')
                        tiles[i, j] = Tile.Goal;
                }
            }
            return tiles;
        }
    }
}