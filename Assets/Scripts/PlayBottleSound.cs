using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBottleSound : MonoBehaviour
{
    public void playBoomSound(AudioClip audioSource)
    {
        AudioSource.PlayClipAtPoint(audioSource, GameManager.instance.player.transform.position, 0.75f);
    }
}
