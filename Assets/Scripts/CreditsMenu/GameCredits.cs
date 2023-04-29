using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCredits : MonoBehaviour
{
    [SerializeField] private string mainMenuLevelTxt = "mainmenu";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(mainMenuLevelTxt);
    }
}
