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
        /// </summary>
        public int[,] tiles;

        public Level(int sizeX, int sizeY)
        {
            tiles = new int[sizeX, sizeY];
        }

        public void PlaceTile(int tileX, int tileY, int tile)
        {
            tiles[tileX, tileY] = tile;
        }
    }
}
