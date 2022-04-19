using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : MonoBehaviour, IInteractable
{
    public AudioClip audioClip;
    public float FearAmount;
    public float radius;
    [SerializeField]
    private LayerMask LayerMask;
    private AudioSource audioSource;
    private CircleCollider2D CircleTrigger;
    private float timeLeft;
    public void interact()
    {
        audioSource.PlayOneShot(audioClip);
        CircleTrigger.enabled = true;
      
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<AudioSource>(out audioSource))
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
        }
        CircleTrigger = GetComponent<CircleCollider2D>();
        CircleTrigger.enabled = false;
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft<0)
        {
            CircleTrigger.enabled = false;
            timeLeft = audioClip.length;
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
