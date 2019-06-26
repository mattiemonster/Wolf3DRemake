namespace GridLevelLib
{
    public class TileInfo
    {
        public string name;
        public string textureName;
        public bool moveable;

        public TileInfo(string name, string texName)
        {
            this.name = name;
            textureName = texName;
            moveable = false;
        }

        public TileInfo(string name, string texName, bool moveable)
        {
            this.name = name;
            textureName = texName;
            this.moveable = moveable;
        }
    }
}
