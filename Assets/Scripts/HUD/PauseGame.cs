using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseGame : MonoBehaviour
{
    [SerializeField] TMP_Text Pause_Txt;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject QuitButton;

    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        SetButtons(false);
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
            Application.Quit();
        }

    }

    void Resume()
    {

    }

    void Pause()
    {

    }

    public void SetButtons(bool condition)
    {
        Pause_Txt.enabled = condition;
        PauseButton.SetActive(condition);
        QuitButton.SetActive(condition);
    }

    public void HUDGamePaused()
    {
        Pause_Txt.enabled = true;
    }

    public void HUDGameNotPaused()
    {
        Pause_Txt.enabled = false;
    }
}
