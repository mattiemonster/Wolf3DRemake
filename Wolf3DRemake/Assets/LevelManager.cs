using UnityEngine;
using TMPro;
using System.Timers;
using System.Diagnostics;
using System;

public class LevelManager : MonoBehaviour
{
    [Header("Scene References - Debug UI")]
    public LevelLoader loader;
    public GameObject debugUI;
    public TextMeshProUGUI levelName;
    public TextMeshProUGUI tileCount;
    public TextMeshProUGUI killCount;
    public TextMeshProUGUI timerText;

    [Header("Scene References - Pause Menu")]
    public GameObject pauseMenu;

    private Stopwatch timer = new Stopwatch();

    void Start()
    {
        debugUI.SetActive(false);
        levelName.text = LevelLoader.levelToLoad;
        tileCount.text = "Tile count: " + loader.tiles.Count.ToString();
        killCount.text = "Kills: 0/" + loader.enemyCount.ToString();
        timerText.text = "Time: 00:00";
        timer.Start();

        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            debugUI.SetActive(!debugUI.activeSelf);

        if (debugUI.activeSelf)
        {
            TimeSpan ts = timer.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.TotalMinutes, ts.Seconds, ts.Milliseconds / 10);
            timerText.text = "Time: " + elapsedTime;
        }
    }

}
