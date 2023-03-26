using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsCanvas : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "mainMenu"; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseSettings()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
