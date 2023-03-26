using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class p1Lives : MonoBehaviour
{
    [SerializeField] private int lives = 3;

    [SerializeField] private AudioClip deathSound;
    // Start is called bef0ore the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 1);
        
        GameManager GM = FindObjectOfType<GameManager>();
        GM.StartCoroutine(GM.ResetGame());
        
        // p1Timer timer = GetComponent<p1Timer>();
        // timer.SetTimer(0);
        
        CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        CinemachineVirtualCamera cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        Destroy(cinemachineBrain);
        Destroy(cinemachineVirtualCamera.gameObject);
        Destroy(this.gameObject);
    }

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int livesToSet)
    {
        lives = livesToSet;
    }

    public void DeductLives(int livesToDeduct)
    {
        lives -= livesToDeduct;
    }

}
