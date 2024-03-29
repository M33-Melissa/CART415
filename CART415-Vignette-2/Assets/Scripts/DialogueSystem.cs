﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Person
{
    Momo,
    Mama
}

[Serializable]
public class PersonDialogue
{
    public Person Person;
    [TextArea] public string Dialogue;
    public UnityEvent dialogueEvent;
}

public class DialogueSystem : MonoBehaviour
{
    public Animator fadeAnimator;
    public Dialogue MamaDialogue;
    public Dialogue MomoDialogue;
    public List<PersonDialogue> DialogueList;

    private Queue<PersonDialogue> dialogQueue;
    private float letterDisplaySpeed = 0.03f;
    private bool isDoneDisplaying = false;
    private PersonDialogue currentPersonDialogue;
    private Dialogue currentDialogue;
    public bool isInitialized = false;

    private void Start()
    {
        dialogQueue = new Queue<PersonDialogue>(DialogueList);
        DisableDialogues();

        isDoneDisplaying = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInitialized)
        {
            if (dialogQueue.Count == 0 && isDoneDisplaying)
            {
                fadeAnimator.SetTrigger("FadeOut");
                return;
            }
            StopAllCoroutines();
            if (isDoneDisplaying)
            {
                NextDialogue();
            }
            else
            {
                FinishDialogue();
            }
        }
    }

    public void InitializeDialogue()
    {
        isInitialized = true;
        NextDialogue();
    }

    private void DisableDialogues()
    {
        MomoDialogue.gameObject.SetActive(false);
        MamaDialogue.gameObject.SetActive(false);
    }

    private void FinishDialogue()
    {
        currentDialogue.SetText(currentPersonDialogue.Dialogue);
        isDoneDisplaying = true;
    }

    private void NextDialogue()
    {
        currentPersonDialogue = dialogQueue.Dequeue();
        currentDialogue = EnableDialogue(currentPersonDialogue.Person);
        currentPersonDialogue.dialogueEvent?.Invoke();

        StartCoroutine(UpdateText(currentDialogue, currentPersonDialogue.Dialogue));
    }
    
    private Dialogue EnableDialogue(Person person)
    {
        if (person == Person.Momo)
        {
            MomoDialogue.gameObject.SetActive(true);
            MamaDialogue.gameObject.SetActive(false);
            return MomoDialogue;
        }
        else
        {
            MomoDialogue.gameObject.SetActive(false);
            MamaDialogue.gameObject.SetActive(true);
            return MamaDialogue;
        }
    }
    private IEnumerator UpdateText(Dialogue dialogue, string text)
    {
        isDoneDisplaying = false;
        string displayText = "";
        foreach(char letter in text.ToCharArray())
        {
            displayText += letter;
            dialogue.SetText(displayText);
            yield return new WaitForSeconds(letterDisplaySpeed);
        }
        isDoneDisplaying = true;
    }
}
