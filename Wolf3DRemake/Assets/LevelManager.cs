using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Scene References")]
    public LevelLoader loader;
    public GameObject debugUI;
    public TextMeshProUGUI levelName;
    public TextMeshProUGUI tileCount;

    void Start()
    {
        debugUI.SetActive(false);
        levelName.text = LevelLoader.levelToLoad;
        tileCount.text = "Tile count: " + loader.tiles.Count.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            debugUI.SetActive(!debugUI.activeSelf);
    }

}
