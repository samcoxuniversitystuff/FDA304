using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFlag : MonoBehaviour
{
    [SerializeField] private GameObject saveSpeechObj;
    
    private bool _canSave = false;

    private Vector2 _playerPos;

    private void Start()
    {
        saveSpeechObj.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _playerPos = col.gameObject.transform.position;
            _canSave = true;
            saveSpeechObj.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canSave = false;
            saveSpeechObj.SetActive(false);
        }
    }

    public bool GetCanSave()
    {
        return _canSave;
    }
}

// References
// https://youtu.be/vZU51tbgMXk