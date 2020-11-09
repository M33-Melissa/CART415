using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinkers : MonoBehaviour
{
    private Sprite eyeSprite;
    [SerializeField] private Sprite closedSprite;
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        eyeSprite = renderer.sprite;

        if (closedSprite == null)
        {
            return;
        }
        StartCoroutine(StartBlinking());
    }

    private IEnumerator StartBlinking()
    {
        while (true)
        {
            float openTimer = Random.Range(2, 5);
            yield return new WaitForSeconds(openTimer);
            renderer.sprite = closedSprite;


            float closeTimer = Random.Range(0.1f, 1);
            yield return new WaitForSeconds(closeTimer);
            renderer.sprite = eyeSprite;
        }
    }
}
