using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDrawing : MonoBehaviour
{
    [SerializeField] private List<GameObject> foodDrawings = null;
    [SerializeField] private DialogueSystem dialogue = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private AudioClip pencilSound = null;

    private Vector3 screenPoint;

    private void OnMouseUp()
    {
        if (foodDrawings.Count > 0)
        {
            SpawnFoodDrawings();
            AudioController.Instance.PlayRandomSfx(pencilSound);
        }
    }

    private void SpawnFoodDrawings()
    {
        int index = UnityEngine.Random.Range(0, foodDrawings.Count);
        foodDrawings[index].SetActive(true);
        
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        foodDrawings[index].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        foodDrawings.RemoveAt(index);

        if(foodDrawings.Count <= 0)
        {
            animator.SetTrigger("FinishDrawing");
            dialogue.InitializeDialogue();
        }
    }


}
