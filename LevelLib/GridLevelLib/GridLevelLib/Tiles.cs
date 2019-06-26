using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GridLevelLib
{
    [Serializable]
    public class Tiles
    {
        public Dictionary<int, TileInfo> tiles = new Dictionary<int, TileInfo>();
        public string textureFolder;
        public string name;

        [XmlIgnore]
        public bool unsavedChanges;

        public Tiles()
        {
            this.textureFolder = null;
        }

        public Tiles(string textureFolder)
        {
            this.textureFolder = textureFolder;
        }

        public void CreateTile(string tileName, string texName)
        {
            tiles.Add(tiles.Count + 1, new TileInfo(tileName, texName));
            unsavedChanges = true;
        }

        public void SaveTiles(string path)
        {
            XmlLoader.SerializeObject(this, path);
            unsavedChanges = false;
        }

        public void RemoveTile(int index)
        {
            tiles.Remove(index);
            unsavedChanges = true;
        }

        public void LoadTiles(string path)
        {
            Tiles loadedTileset = XmlLoader.DeSerializeObject<Tiles>(path);
            tiles = loadedTileset.tiles;
            textureFolder = loadedTileset.textureFolder;
            name = loadedTileset.name;
        }

        public TileInfo GetTileInfo(int tileIndex)
        {
            return tiles[tileIndex];
        }

        public string GetTileTextureName(int tileIndex)
        {
            return tiles[tileIndex].textureName;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            name = newName;
            unsavedChanges = true;
        }

        public string GetTexturesFolder()
        {
            return textureFolder;
        }

        public void SetTexturesFolder(string newPath)
        {
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);

            textureFolder = newPath;
            unsavedChanges = true;
        }
    }
}
