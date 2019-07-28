using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class LevelLoader : MonoBehaviour
{
    public static string levelToLoad;
    public List<TileInfo> tiles = new List<TileInfo>();

    void Start()
    {
        if (string.IsNullOrEmpty(levelToLoad))
            return;
        else
        {
            if (!File.Exists(Application.persistentDataPath + "/Wolf3DLevels/" + levelToLoad + ".xml"))
            {
                Debug.Log("Level " + Application.persistentDataPath + "/Wolf3DLevels/" + levelToLoad + ".xml not found.");
                return;
            }
            else
            {
                Debug.Log("Opening level " + Application.persistentDataPath + "/Wolf3DLevels/" + levelToLoad + ".xml");
                OpenLevel(new StreamReader(Application.persistentDataPath + "/Wolf3DLevels/" + levelToLoad + ".xml"));
            }
        }
    }

    public void OpenLevel(StreamReader file)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<TileInfo>));
        tiles = (List<TileInfo>)serializer.Deserialize(file.BaseStream);
        file.Close();
        LoadTiles();
    }

    public void LoadTiles()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            Instantiate(Resources.Load(tiles[i].prefabName), tiles[i].position, Quaternion.identity);
        }
    }

}
