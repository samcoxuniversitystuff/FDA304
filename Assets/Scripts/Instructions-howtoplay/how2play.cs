using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class how2play : MonoBehaviour
{
    [SerializeField] private string mainMenuName = "mainmenu";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(mainMenuName);
    }
}
