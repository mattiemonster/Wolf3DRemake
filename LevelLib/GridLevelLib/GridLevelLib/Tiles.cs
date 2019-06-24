using System;
using System.Collections.Generic;

namespace GridLevelLib
{
    [Serializable]
    class Tiles
    {
        public Dictionary<int, TileInfo> tiles = new Dictionary<int, TileInfo>();
        public string textureFolder;

        public Tiles(string textureFolder)
        {
            this.textureFolder = textureFolder;
        }

        public void LoadTiles(string path, string texturesPath)
        {
            tiles = XmlLoader.DeSerializeObject<Dictionary<int, TileInfo>>(path);
        }

        public void CreateTile(string tileName, string texName)
        {
            tiles.Add(tiles.Count + 1, new TileInfo(tileName, texName));
        }

        public void SaveTiles(string path)
        {
            XmlLoader.SerializeObject(tiles, path);
        }

        public TileInfo GetTileInfo(int tileIndex)
        {
            return tiles[tileIndex];
        }

        public string GetTileTextureName(int tileIndex)
        {
            return tiles[tileIndex].textureName;
        }
    }
}
