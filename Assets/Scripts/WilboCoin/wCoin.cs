using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wCoin : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 1;

    [SerializeField] private AudioClip moneySound;
    [SerializeField] private float moneySoundVolume = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            CollectMoney();
        }
    }

    public void CollectMoney()
    {
        AudioSource.PlayClipAtPoint(moneySound, transform.position);
        p1Score playerScore = FindObjectOfType<p1Score>();
        playerScore.AddScore(scoreToAdd);
        Destroy(this.gameObject);
    }
}
