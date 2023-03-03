using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class p1Lives : MonoBehaviour
{
    [SerializeField] private int lives = 3;
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
        CinemachineBrain _cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        CinemachineVirtualCamera _cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        Destroy(_cinemachineBrain);
        Destroy(_cinemachineVirtualCamera.gameObject);
        p1Timer p1Timer = GetComponent<p1Timer>();
        p1Timer.SetTimer(0);
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
