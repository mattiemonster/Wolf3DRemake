using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scene References")]
    public GameObject customMapDialog;
    public TMP_InputField mapNameInput;
    public TextMeshProUGUI mapNameInputText;

    void Start()
    {
        if (!customMapDialog)
            Debug.LogError("Main menu custom map dialog is unassigned!");
        else
            customMapDialog.SetActive(false);

        if (!mapNameInput)
            Debug.LogError("Map name input field is unassigned!");
    }

    public void ShowCustomMapDialog()
    {
        customMapDialog.SetActive(true);
    }

    public void HideCustomMapDialog()
    {
        customMapDialog.SetActive(false);
    }

    public void LoadEditor()
    {
        SceneManager.LoadScene("Editor");
    }

    public void LoadLevel(string name)
    {
        if (!File.Exists(Application.persistentDataPath + "/Wolf3DLevels/" + mapNameInput.text + ".xml"))
        {
            mapNameInputText.color = Color.red;
        } else
        {
            
        }
    }

    public void LoadLevelFromInput()
    {
        LoadLevel(mapNameInput.text);
    }

    public void ResetMapNameInputColour()
    {
        mapNameInputText.color = Color.black;
    }

}
