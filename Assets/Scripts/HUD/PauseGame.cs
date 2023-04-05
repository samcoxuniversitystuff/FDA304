using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] TMP_Text Pause_Txt;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject QuitButton;
    [SerializeField] GameObject PauseObj;

    public static bool isPaused = false;

    [SerializeField] private string mainMenuName;
    // Start is called before the first frame update
    void Start()
    {
        PauseObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && isPaused)
        {
            Quit();
        }

    }

    public void Resume()
    {
        PauseObj.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        PauseObj.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Reset()
    {
        Resume();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
}
