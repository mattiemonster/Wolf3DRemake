using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GridLevelLib
{
    [Serializable]
    public class Tiles
    {
        public SerializableDictionary<string, TileInfo> tiles = new SerializableDictionary<string, TileInfo>();
        public string textureFolder;
        public string oldTexturesFolder;
        public bool copyTextures;
        public string name;

        [XmlIgnore]
        public bool unsavedChanges;

        [XmlIgnore]
        public Dictionary<string, int> nameToIndex = new Dictionary<string, int>();

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
            tiles.Add(tileName, new TileInfo(tileName, texName));
            unsavedChanges = true;
        }

        public void SaveTiles(string path)
        {
            XmlLoader.SerializeObject(this, path);
            unsavedChanges = false;
        }

        public void RemoveTile(string name)
        {
            tiles.Remove(name);
            unsavedChanges = true;
        }

        public void LoadTiles(string path)
        {
            Tiles loadedTileset = XmlLoader.DeSerializeObject<Tiles>(path);
            tiles = loadedTileset.tiles;
            textureFolder = loadedTileset.textureFolder;
            name = loadedTileset.name;
        }

        public TileInfo GetTileInfo(string name)
        {
            return tiles[name];
        }

        public string GetTileTextureName(string name)
        {
            return tiles[name].textureName;
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
            if (!Directory.Exists(newPath) && newPath != "/Textures/")
                Directory.CreateDirectory(newPath);

            if (newPath == "/Textures/")
                SetOldTexturesFolder(textureFolder);

            textureFolder = newPath;
            unsavedChanges = true;
        }

        public string GetOldTexturesFolder()
        {
            return oldTexturesFolder;
        }

        public void SetOldTexturesFolder(string newPath)
        {
            oldTexturesFolder = newPath;
            unsavedChanges = true;
        }

        public void RenameTile(string tileName, string newTileName)
        {
            TileInfo newTile = tiles[tileName];
            newTile.name = newTileName;
            tiles.Remove(tileName);
            tiles.Add(newTileName, newTile);
        }
    }
}
