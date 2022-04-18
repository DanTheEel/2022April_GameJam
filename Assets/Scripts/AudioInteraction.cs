using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : MonoBehaviour, IInteractable
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    public void interact()
    {
        audioSource.PlayOneShot(audioClip);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<AudioSource>(out audioSource))
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
        }
    }
}
