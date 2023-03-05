using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Timer : MonoBehaviour
{

    [SerializeField] float timer = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            p1Lives _p1lives = GetComponent<p1Lives>();
            _p1lives.SetLives(0);
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    public void SetTimer(int timerToSet)
    {
        timer = timerToSet;
    }
}
