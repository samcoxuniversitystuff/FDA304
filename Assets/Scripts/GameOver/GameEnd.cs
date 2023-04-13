using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private string firstlevelname = "level01";

    [SerializeField] private string mainmenuname = "mainmenu";

    [SerializeField] private string feedbackURL;

    [SerializeField] private GameObject quitButton;

    private void Awake()
    {
        CheckForWebGL();
    }

    void CheckForWebGL()
    {

        #if UNITY_WEBGL
        quitButton.SetActive(false);
        #endif
    }

    public void Loadfirstlevel()
    {
        SceneManager.LoadScene(firstlevelname);
    }

    public void Loadmainmenu()
    {
        SceneManager.LoadScene(mainmenuname);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ProvideFeedback()
    {
        Application.OpenURL(feedbackURL);
    }
}
