using UnityEngine;
using TMPro;
using System.Timers;
using System.Diagnostics;
using System;
using System.Collections;

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
    public TextMeshProUGUI levelNamePause;

    [Header("Properties - Pause Menu")]
    public float openMenuAnimTime;
    public float closeMenuAnimTime;

    private Stopwatch timer = new Stopwatch();

    private bool pauseMenuOpen = false;
    private bool allowAnim = true;

    void Start()
    {
        debugUI.SetActive(false);
        levelName.text = LevelLoader.levelToLoad;
        tileCount.text = "Tile count: " + loader.tiles.Count.ToString();
        killCount.text = "Kills: 0/" + loader.enemyCount.ToString();
        timerText.text = "Time: 00:00";
        timer.Start();

        pauseMenu.SetActive(false);
        levelNamePause.text = LevelLoader.levelToLoad;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!allowAnim) return;

            if (pauseMenuOpen)
                CloseMenu();
            else
                OpenMenu();
        }
    }

    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        allowAnim = false;
        pauseMenu.GetComponent<Animator>().Play("OpenMenu");
        StartCoroutine(AllowAnimPlay(openMenuAnimTime));
        StartCoroutine(PauseMenuEnable(openMenuAnimTime, true));
        pauseMenuOpen = true;
    }

    public IEnumerator AllowAnimPlay(float time)
    {
        yield return new WaitForSeconds(time);
        allowAnim = true;
    }

    public IEnumerator PauseMenuEnable(float time, bool value)
    {
        yield return new WaitForSeconds(time);
        pauseMenu.SetActive(value);
    }

    public void CloseMenu()
    {
        pauseMenu.SetActive(true);
        allowAnim = false;
        pauseMenu.GetComponent<Animator>().Play("CloseMenu");
        StartCoroutine(AllowAnimPlay(closeMenuAnimTime));
        StartCoroutine(PauseMenuEnable(closeMenuAnimTime, false));
        pauseMenuOpen = false;
    }

}
