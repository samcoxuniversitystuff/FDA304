using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuCanvas : MonoBehaviour
{
    [SerializeField] private string firstLevelName = "level01";

    [SerializeField] private string instructionsLevelName = "HowToPlay";
    
    [SerializeField] private string settingsLevelName = "settings";
    
    [SerializeField] private string feedbackURL;

    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject quitButton;

    private void Awake()
    {
        CheckForWebGL();

    }

    void CheckForWebGL()
    {
        #if UNITY_WEBGL
        settingsButton.SetActive(false);
        quitButton.SetActive(false);
        #endif
    }

    public void OpenLvl01()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(firstLevelName);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(settingsLevelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenInstructions()
    {
        SceneManager.LoadScene(instructionsLevelName);
    }
    
    public void ProvideFeedback()
    {
        Application.OpenURL(feedbackURL);
    }
}
