using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Wilbo1NPC : MonoBehaviour
{
    [SerializeField] private GameObject speechBubbleObj;

    [SerializeField] private WilboDialogueObj _wilboDialogueObj;
    private int _dialogueNumber = 0;
    private int _dialogueNumberEnd;

    [SerializeField] private TMP_Text dialogBoxText;
    // Start is called before the first frame update
    void Start()
    {
        speechBubbleObj.SetActive(false);
        _dialogueNumberEnd = (_wilboDialogueObj.dialogue.Length - 1);
        UpdateWilboDialogue(_dialogueNumber);
    }
    
    void Update()
    {
        Debug.Log("Current Dialogue Number: " + _dialogueNumber);
        Debug.Log("Last Dialogue Number: " + _dialogueNumberEnd);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (_dialogueNumber + 1 <= _dialogueNumberEnd)
            {
                _dialogueNumber++;
                UpdateWilboDialogue(_dialogueNumber);
            }
            else if (_dialogueNumber + 1 > _dialogueNumberEnd)
            {
                _dialogueNumber = 0;
                UpdateWilboDialogue(_dialogueNumber);
            }
            

        }
    }
    

    void UpdateWilboDialogue(int num)
    {
        dialogBoxText.text = _wilboDialogueObj.dialogue[num];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speechBubbleObj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        speechBubbleObj.SetActive(false);
    }


}
