using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text DialogueText;

    public void SetText(string text)
    {
        DialogueText.text = text;
    }
}
