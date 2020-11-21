using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogue;
    private int numOfMonsters;
    private int numClicks = 0;
    private int waitTime = 2;

    private void Start()
    {
        numOfMonsters = transform.childCount;
    }

    public void mouseDown(GameObject clickedObject)
    {
        StartCoroutine(HideEye(clickedObject));
        numClicks++;
    }

    private void CheckForVictory()
    {
        if (numOfMonsters <= 0)
        {
            dialogue.InitializeDialogue();
            StopAllCoroutines();
        }
    }
    private IEnumerator HideEye(GameObject eye)
    {
        eye.SetActive(false);
        numOfMonsters--;
        CheckForVictory();
        waitTime += numClicks / 2;
        yield return new WaitForSeconds(waitTime);

        eye.SetActive(true);
        numOfMonsters++;
    }
}
