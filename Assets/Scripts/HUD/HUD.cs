using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text HUDtxt;

    [SerializeField] p1Timer _p1Timer;
    [SerializeField] p1Lives _p1Lives;
    [SerializeField] p1Score _p1Score;

    // Start is called before the first frame update
    void Start()
    {
        HUDtxt = GetComponentInChildren<TMP_Text>();
        if (HUDtxt != null)
        {
            Debug.Log("The HUD is not null.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText()
    {
        string timerTxt = _p1Timer.GetTimer().ToString();
        string scoreTxt = _p1Score.GetScore().ToString();
        string livesTxt = _p1Lives.GetLives().ToString();
        string textToUpdate = "score: " + scoreTxt + "\nlives: " + livesTxt + "\nlives: " + timerTxt;
        HUDtxt.text = textToUpdate;
    }
}
