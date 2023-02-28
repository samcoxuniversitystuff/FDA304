using System.Collections;
using System.Collections.Generic;
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
