using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridLevelLib
{
    [Serializable]
    public class Level
    {
        /// <summary>
        /// Each level is represented by a 2d array of ints.
        /// Tile value of -1 is an empty tile.
        /// </summary>
        public int[,] tiles;

        public Level(int sizeX, int sizeY)
        {
            tiles = new int[sizeX, sizeY];

            // Set all tiles to an empty tile
            for (int k = 0; k < tiles.GetLength(0); k++)
                for (int l = 0; l < tiles.GetLength(1); l++)
                    tiles[k, l] = -1;
        }

        public void PlaceTile(int tileX, int tileY, int tile)
        {
            tiles[tileX, tileY] = tile;
        }

        public void ResetTile(int tileX, int tileY)
        {
            tiles[tileX, tileY] = -1; // Tile becomes empty
        }
    }
}
