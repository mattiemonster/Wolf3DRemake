using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
    public TextMeshProUGUI exitPause;

    [Header("Properties - Pause Menu")]
    public float openMenuAnimTime;
    public float closeMenuAnimTime;

    [HideInInspector]
    public static bool loadedFromEditor;

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
        if (loadedFromEditor) exitPause.text = "Return to Editor";

        Destroy(GameObject.Find("Main Camera"));
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
        GameObject.Find("Player").GetComponent<PlayerController>().acceptInput = false;
        GameObject.Find("PlayerCamera").GetComponent<PlayerMouseLook>().UnlockCursor();
        timer.Stop();
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
        GameObject.Find("Player").GetComponent<PlayerController>().acceptInput = true;
        GameObject.Find("PlayerCamera").GetComponent<PlayerMouseLook>().LockCursor();
        timer.Start();
        StartCoroutine(AllowAnimPlay(closeMenuAnimTime));
        StartCoroutine(PauseMenuEnable(closeMenuAnimTime, false));
        pauseMenuOpen = false;
    }

    public bool IsPauseMenuOpen()
    {
        return pauseMenuOpen;
    }

    public void Quit()
    {
        if (loadedFromEditor)
            SceneManager.LoadScene("Editor");
        else
            SceneManager.LoadScene("Menu");
    }

}
