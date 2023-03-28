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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLvl01()
    {
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
