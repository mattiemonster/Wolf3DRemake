using UnityEngine;
using System;
using System.Xml.Serialization;

[Serializable]
public class TileInfo
{
    /// <summary>
    /// The position of the tile, should be whole numbers.
    /// </summary>
    public Vector3 position;
    /// <summary>
    /// The name of the prefab of the tile that is stored in the Resources folder.
    /// Example: "WallStone"
    /// </summary>
    public string prefabName;

    [XmlIgnore]
    public GameObject gameObject;

    public TileInfo()
    { }

    public TileInfo(Vector3 position, string prefabName, GameObject gameObject)
    {
        this.position = position;
        this.prefabName = prefabName;
        this.gameObject = gameObject;
    }
}
