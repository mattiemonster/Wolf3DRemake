using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEditor : MonoBehaviour
{
    [Header("Editor Values")]
    public List<TileInfo> tiles = new List<TileInfo>();
    public string levelName = "Untitled";

    [Header("Scene References")]
    public TextMeshProUGUI levelNameText;
    public TMP_InputField newNameInput;
    public GameObject renameLevelDialog;
    public SelectionBox selectionBox;
    public EditorCamera editorCamera;
    public GameObject loadLevelDialog;
    public TMP_InputField loadLevelInput;
    public GameObject levelNotFoundText;
    public GameObject exitEditorDialog;

    [Header("Tile Selection UI")]
    public GameObject selectionUIParent;
    public string tile1Prefab;
    public string tile2Prefab;
    public string tile3Prefab;
    public string tile4Prefab;
    public string tile5Prefab;
    public string tile6Prefab;
    public string tile7Prefab;
    public string tile8Prefab;
    public string tile9Prefab;
    public string tile0Prefab;
    public Color unselectedColour;
    public Color selectedColour;

    private string[] prefabNames = new string[10];
    private int currentTile = 0;

    void Start()
    {
        #region Unassigned warnings
        if (!levelNameText)
            Debug.LogError("Level name text reference is unassigned!");

        if (!newNameInput)
            Debug.LogError("New name input field reference is unassigned!");

        if (!renameLevelDialog)
            Debug.LogError("Rename level dialog reference is unassigned!");

        if (!selectionBox)
            Debug.LogError("Selection box reference is unassigned!");

        if (!editorCamera)
            Debug.LogError("Editor camera reference is unassigned!");

        if (!loadLevelDialog)
            Debug.LogError("Load level dialog reference is unassigned!");

        if (!loadLevelInput)
            Debug.LogError("Load level input box reference is unassigned!");

        if (!levelNotFoundText)
            Debug.LogError("Level not found text reference is unassigned!");

        if (!exitEditorDialog)
            Debug.LogError("Exit editor dialog reference is unassigned!");
        #endregion

        InitPrefabList();
        SelectTile(1);
    }

    public void InitPrefabList()
    {
        prefabNames[0] = tile0Prefab;
        prefabNames[1] = tile1Prefab;
        prefabNames[2] = tile2Prefab;
        prefabNames[3] = tile3Prefab;
        prefabNames[4] = tile4Prefab;
        prefabNames[5] = tile5Prefab;
        prefabNames[6] = tile6Prefab;
        prefabNames[7] = tile7Prefab;
        prefabNames[8] = tile8Prefab;
        prefabNames[9] = tile9Prefab;
    }

    public void SelectTile(int index)
    {
        selectionUIParent.transform.Find("Tile0" + currentTile.ToString())
            .GetComponent<Image>().color = unselectedColour;
        currentTile = index;
        selectionUIParent.transform.Find("Tile0" + currentTile.ToString())
            .GetComponent<Image>().color = selectedColour;
    }

    public void RenameLevel(string newName)
    {
        levelName = newName;
        levelNameText.text = newName;
    }

    public void RenameFromInputField()
    {
        string newName = newNameInput.text;
        if (string.IsNullOrEmpty(newName)) return;
        levelName = newName;
        levelNameText.text = newName;
        renameLevelDialog.SetActive(false);
        selectionBox.acceptInput = true;
        editorCamera.acceptInput = true;
    }

    public void OpenRenameLevelDialog()
    {
        newNameInput.text = levelName;
        renameLevelDialog.SetActive(true);
        selectionBox.acceptInput = false;
        editorCamera.acceptInput = false;
        editorCamera.ResetInput();
    }

    public void CloseRenameLevelDialog()
    {
        renameLevelDialog.SetActive(false);
        selectionBox.acceptInput = true;
        editorCamera.acceptInput = true;
    }

    public void OpenLoadLevelDialog()
    {
        loadLevelInput.text = "";
        loadLevelDialog.SetActive(true);
        levelNotFoundText.SetActive(false);
        selectionBox.acceptInput = false;
        editorCamera.acceptInput = false;
        editorCamera.ResetInput();
    }

    public void OpenLevelFromInput()
    {
        if (!File.Exists(Application.persistentDataPath + "/Wolf3DLevels/" + loadLevelInput.text + ".xml"))
        {
            levelNotFoundText.SetActive(true);
            Debug.Log("Level " + Application.persistentDataPath + "/Wolf3DLevels/" + loadLevelInput.text + ".xml not found.");
            return;
        } else
        {
            Debug.Log("Opening level " + Application.persistentDataPath + "/Wolf3DLevels/" + loadLevelInput.text + ".xml");
            OpenLevel(new StreamReader(Application.persistentDataPath + "/Wolf3DLevels/" + loadLevelInput.text + ".xml"));
        }
    }

    public void OpenLevel(StreamReader file)
    {
        ClearEditor();
        XmlSerializer serializer = new XmlSerializer(typeof(List<TileInfo>));
        tiles = (List<TileInfo>)serializer.Deserialize(file.BaseStream);
        RenameLevel(loadLevelInput.text);
        file.Close();
        LoadTiles();
        CloseLoadLevelDialog();
    }

    public void LoadTiles()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].prefabName == "Player")
            {
                tiles[i].gameObject = (GameObject)Instantiate(Resources.Load("EditorPlayer"), tiles[i].position, Quaternion.identity);
            }
            else
            {
                tiles[i].gameObject = (GameObject)Instantiate(Resources.Load(tiles[i].prefabName), tiles[i].position, Quaternion.identity);
            }
        }
    }

    public void CloseLoadLevelDialog()
    {
        loadLevelDialog.SetActive(false);
        selectionBox.acceptInput = true;
        editorCamera.acceptInput = true;
    }

    public void ClearEditor()
    {
        // TODO Optionally show an 'are you sure?' message

        foreach (TileInfo tile in tiles)
        {
            Destroy(tile.gameObject);
        }
        tiles.Clear();
    }

    public void SaveLevel()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<TileInfo>));
        if (!Directory.Exists(Application.persistentDataPath + "/Wolf3DLevels/"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Wolf3DLevels/");
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/Wolf3DLevels/" + levelName + ".xml");
        serializer.Serialize(writer.BaseStream, tiles);
        writer.Close();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void OpenExitEditorDialog()
    {
        exitEditorDialog.SetActive(true);
        selectionBox.acceptInput = false;
        editorCamera.acceptInput = false;
        editorCamera.ResetInput();
    }

    public void CloseExitEditorDialog()
    {
        exitEditorDialog.SetActive(false);
        selectionBox.acceptInput = true;
        editorCamera.acceptInput = true;
    }

    public string GetCurrentPrefab()
    {
        return prefabNames[currentTile];
    }

    public void SaveAndPlay()
    {
        SaveLevel();
        LevelLoader.levelToLoad = levelName;
        SceneManager.LoadSceneAsync("Level");
    }

}
