using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : MonoBehaviour, IInteractable
{
    public AudioClip audioClip;
    public float FearAmount;
    public float radius;
 
 
    private AudioSource audioSource;
    private CircleCollider2D CircleTrigger;       
    private float timeLeft;
    public void interact()
    {
        audioSource.PlayOneShot(audioClip);
        CircleTrigger.enabled = true;
        Distraction_System.instance.ActivateDistraction(this.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag != "Interactable")
        {
            this.gameObject.tag = "Interactable";
        }
        if (!TryGetComponent<AudioSource>(out audioSource))
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
        }      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("NPC"))
        {
            FearMeter.instance.AddFear(FearAmount);
            //npc reaction
        }
    }
}
