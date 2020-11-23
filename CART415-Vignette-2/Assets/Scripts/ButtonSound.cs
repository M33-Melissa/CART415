using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip pageSound = null;

    public void PlayPageTurnSound()
    {
        AudioController.Instance.PlayRandomSfx(pageSound);
    }
}
