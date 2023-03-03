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
        Destroy(_cinemachineBrain);
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
