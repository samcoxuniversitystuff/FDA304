using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class settingsCanvas : MonoBehaviour
{


    private Resolution[] computerResolutions;
    
    [SerializeField] private string mainMenuSceneName = "mainMenu";

    [SerializeField] TMP_Dropdown ResDropdown;

    private void Start()
    {
        computerResolutions = Screen.resolutions;
        
        ResDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int PCResIndex = 0;

        for (int i = 0; i < computerResolutions.Length; i++)
        {
            string resOption = computerResolutions[i].width + "x" + computerResolutions[i].height + "@" + computerResolutions[i].refreshRateRatio + "hz";
            resOptions.Add(resOption);

            if (computerResolutions[i].width == Screen.currentResolution.width && computerResolutions[i].height == Screen.currentResolution.height)
            {
                PCResIndex = i;
            }
        }
        
        ResDropdown.AddOptions(resOptions);
        ResDropdown.value = PCResIndex;
        ResDropdown.RefreshShownValue();
    }
    public void FullscreenMode(bool newFullscreenMode)
    {
        Screen.fullScreen = newFullscreenMode;
    }

    public void SetGameRes(int resToSetIndex)
    {
        Resolution gameRes = computerResolutions[resToSetIndex];
        Screen.SetResolution(gameRes.width, gameRes.height, Screen.fullScreen);
    }

    public void CloseSettings()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
