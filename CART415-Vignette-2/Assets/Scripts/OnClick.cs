using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    private ClickManager clickManager;
    private void Start()
    {
        clickManager = GetComponentInParent<ClickManager>();
    }

    private void OnMouseDown()
    {
        clickManager.mouseDown(gameObject);
    }
}
