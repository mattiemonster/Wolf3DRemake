using System;
using System.Drawing;

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
        public Color floorColour, ceilingColour;

        public Level(int sizeX, int sizeY, Color floor, Color ceiling)
        {
            tiles = new int[sizeX, sizeY];
            floorColour = floor;
            ceilingColour = ceiling;

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

        public void SaveLevel(string path)
        {
            XmlLoader.SerializeObject(this, path);
        }

        public void LoadLevel(string path)
        {
            Level loadedLevel = XmlLoader.DeSerializeObject<Level>(path);

            tiles = loadedLevel.tiles;
            floorColour = loadedLevel.floorColour;
            ceilingColour = loadedLevel.ceilingColour;
        }

        public Level LoadAndGetLevel(string path)
        {
            return XmlLoader.DeSerializeObject<Level>(path);
        }

        public Color GetFloorColour()
        {
            return floorColour;
        }

        public void SetFloorColour(Color newColour)
        {
            floorColour = newColour;
        }

        public Color GetCeilingColour()
        {
            return ceilingColour;
        }

        public void SetCeilingColour(Color newColour)
        {
            ceilingColour = newColour;
        }
    }
}
