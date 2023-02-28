using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text Score_Txt;
    [SerializeField] TMP_Text Lives_Txt;
    [SerializeField] TMP_Text Timer_Txt;

    p1Timer _p1Timer;
    p1Lives _p1Lives;
    p1Score _p1Score;

    // Start is called before the first frame update
    void Start()
    {
        _p1Timer = FindObjectOfType<p1Timer>();
        _p1Lives = FindObjectOfType<p1Lives>();
        _p1Score = FindObjectOfType<p1Score>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        string timerTxt = _p1Timer.GetTimer().ToString("F2");
        string scoreTxt = _p1Score.GetScore().ToString();
        string livesTxt = _p1Lives.GetLives().ToString();

        Timer_Txt.text = "timer = " + timerTxt;
        Score_Txt.text = "score = " + scoreTxt;
        Lives_Txt.text = "lives = " + livesTxt;
    }
}
