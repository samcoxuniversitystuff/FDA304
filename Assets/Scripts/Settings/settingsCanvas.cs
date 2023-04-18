using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class settingsCanvas : MonoBehaviour
{

    
    [SerializeField] private string mainMenuSceneName = "mainMenu";

    [SerializeField] TMP_Dropdown FullscreenDropdown;
    [SerializeField] TMP_Dropdown GraphicsDropdown;
    [SerializeField] TMP_Dropdown ResDropdown;

    Resolution[] resOptions;



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

    public void SetScreenMode(bool OnFullscreenMode)
    {
        Screen.fullScreen = OnFullscreenMode;
    }

    public void SetRes(int resIndex)
    {
        Resolution currentRes = resOptions[resIndex];
        Screen.SetResolution(currentRes.width, currentRes.height, Screen.fullScreen);
    }
}
