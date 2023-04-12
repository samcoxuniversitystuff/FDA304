using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    
    [FormerlySerializedAs("ResetTime")] [SerializeField] private float resetTime = 3;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ResetGame());
        }
    }

    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(resetTime);
        Time.timeScale = 1f;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(resetTime);
        Time.timeScale = 1f;
        Vector3 newPlayerPos = new Vector3(PlayerPrefs.GetInt("PlayerX"), PlayerPrefs.GetInt("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        GameObject newPlayer = Instantiate(playerObj, newPlayerPos, Quaternion.identity);
        pCamera playerCam = FindObjectOfType<pCamera>();
        playerCam.UpdateFollowObj(newPlayer);
        Debug.Log("Spawned new player.");
    }
}
