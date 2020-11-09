using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogue;
    [SerializeField] private Animator animator;
    public GameObject sceneObjects;

    private int numOfObject;

    private void Start()
    {
        numOfObject = sceneObjects.transform.childCount;
    }

    public void SelectionUp(GameObject selection)
    {
        Destroy(selection);

        numOfObject--;
        if (numOfObject <= 0)
        {
            Debug.Log("Bravo esti");
            // Load next scene or display dialogue
            animator.Play("Anim_MomoStudyComplete");
            dialogue.InitializeDialogue();
        }
    }
}
