using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [FormerlySerializedAs("Score_Txt")] [SerializeField] TMP_Text scoreTxt;
    [FormerlySerializedAs("Lives_Txt")] [SerializeField] TMP_Text livesTxt;
    [SerializeField] private GameObject keySilhouette;

    
    private p1Lives _p1Lives;
    private p1Score _p1Score;
    private p1Shooting _p1Shooting;

    [SerializeField] private Image weaponHUD;
    [SerializeField] private Sprite arrowImg;
    [SerializeField] private Sprite swordImg;

    
    // Start is called before the first frame update
    void Start()
    {
        _p1Lives = FindObjectOfType<p1Lives>();
        _p1Score = FindObjectOfType<p1Score>();
        _p1Shooting = FindObjectOfType<p1Shooting>();
        DisableKeyImage();

    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerWeapon();
        UpdateText();
    }

    void UpdateText()
    {
        // string timerTxt = _p1Timer.GetTimer().ToString("F2");
        string scoreTxt = _p1Score.GetScore().ToString();
        string livesTxt = _p1Lives.GetLives().ToString();

        // this.timerTxt.text = "timer = " + timerTxt;
        this.scoreTxt.text = "score = " + scoreTxt;
        this.livesTxt.text = "lives = " + livesTxt;
        // float hudStamina = (_p1Stamina.GetStamina() / 100);
        // staminaBar.value = hudStamina;
        // print("hudStamina: " + hudStamina);
    }

    public void EnableKeyImage()
    {
        keySilhouette.SetActive(true);
    }

    public void DisableKeyImage()
    {
        keySilhouette.SetActive(false);
    }

    public void GetPlayerWeapon()
    {
        if (_p1Shooting.GetShootingMode())
        {
            weaponHUD.sprite = arrowImg;
        }
        else if (!_p1Shooting.GetShootingMode())
        {
            weaponHUD.sprite = swordImg;
        }
    }



}
