using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip goalSFX;
    public AudioClip deathSFX;
    

    // Called before start
    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayEndGameSound (bool won) {
        if (!won) audioSource.PlayOneShot(deathSFX, 1f);
        else if (won) audioSource.PlayOneShot(goalSFX, 1f);
    }
}
