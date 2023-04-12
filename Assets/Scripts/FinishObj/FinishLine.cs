using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private string gameOverLevelName = "GameOver";

    [SerializeField] private bool lastLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (lastLevel)
            {
                SceneManager.LoadScene(gameOverLevelName);
            }
            else if (!lastLevel)
            {
                int currentLevel = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentLevel + 1);
            }
        }
    }
}

// https://answers.unity.com/questions/1169114/how-to-load-next-scene-in-unity-5.html

