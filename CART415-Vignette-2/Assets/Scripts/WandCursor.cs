using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandCursor : MonoBehaviour
{
    public Texture2D wand;
    void Start()
    {
        Cursor.SetCursor(wand, Vector2.zero, CursorMode.ForceSoftware);
    }
}
