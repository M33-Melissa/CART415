using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 screenPoint;

    public void OnMouseDrag()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseUp()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, new Vector2(0, 0), 0.01f);

        foreach (var hit in hits)
        {
            Drop drop = hit.transform.GetComponent<Drop>();
            if (drop == null)
            {
                return;
            }
            drop.SelectionUp(gameObject);
        }
    }
}
