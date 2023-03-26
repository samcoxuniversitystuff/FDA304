using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private string firstlevelname = "level01";

    [SerializeField] private string mainmenuname = "mainmenu";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
