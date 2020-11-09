using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogue;
    private int numOfMonsters;

    private void Start()
    {
        numOfMonsters = transform.childCount;
    }

    public void mouseDown(GameObject clickedObject)
    {
        Destroy(clickedObject);

        numOfMonsters--;
        if (numOfMonsters <= 0)
        {
            Debug.Log("Bravo esti");
            // Load next scene or display dialogue
            dialogue.InitializeDialogue();
        }
    }
}
