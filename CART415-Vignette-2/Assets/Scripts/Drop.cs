using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogue;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip munchSound = null;
    public GameObject sceneObjects;

    private int numOfObject;

    private void Start()
    {
        numOfObject = sceneObjects.transform.childCount;
    }

    public void SelectionUp(GameObject selection)
    {
        Destroy(selection);

        animator.SetTrigger("Eat");
        numOfObject--;
        AudioController.Instance.PlayRandomSfx(munchSound);
        if (numOfObject <= 0)
        {
            // Load next scene or display dialogue
            animator.Play("Anim_MomoStudyComplete");
            dialogue.InitializeDialogue();
        }
    }
}
