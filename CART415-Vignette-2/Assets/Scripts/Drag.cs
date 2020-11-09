using UnityEngine;

public class Drag : MonoBehaviour
{
    private Sprite scienceSprite;
    [SerializeField] private Sprite candySprite;
    
    private Animator shakeAnimator;
    private Vector3 screenPoint;
    private SpriteRenderer renderer;


    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        shakeAnimator = GetComponent<Animator>();
        scienceSprite = renderer.sprite;
    }

    private void OnMouseEnter()
    {
        shakeAnimator.SetBool("IsShaking", true);
    }


    private void OnMouseDown()
    {
        if (candySprite == null)
        {
            return;
        }
        renderer.sprite = candySprite;
    }

    public void OnMouseDrag()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseUp()
    {
        shakeAnimator.SetBool("IsShaking", false);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, new Vector2(0, 0), 0.01f);

        foreach (var hit in hits)
        {
            Drop drop = hit.transform.GetComponent<Drop>();
            if (drop == null)
            {
                renderer.sprite = scienceSprite;
                return;
            }
            drop.SelectionUp(gameObject);
        }
    }
}
