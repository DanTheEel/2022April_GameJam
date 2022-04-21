using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : MonoBehaviour, IInteractable
{
    public AudioClip audioClip;
    public float FearAmount;
    public float radius;

    public AnimationTrigger anim;

    public ParticleSystem particle;
    private bool isTriggered = false;
    private bool activeScare = false;

    private AudioSource audioSource;
    private CircleCollider2D CircleTrigger;       
    private float timeLeft;
    public void interact()
    {
        audioSource.PlayOneShot(audioClip);
        //CircleTrigger.enabled = true;
        if (Waypoint_System.instance.GetCurrentRoom().interactables.Contains(this.gameObject))
        {
            Distraction_System.instance.ActivateDistraction(this.transform);
            Distraction_System.instance.ActivateDistractionVisuals();
        }
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

        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTriggered)
        {
            if (!activeScare)
            {
                anim.SetAnimation();
                StartCoroutine(PlayParticles());
                activeScare = true;
            }
            if (activeScare)
            {
                Debug.Log("You currently have an active scare! Wait until it is finished.");
            }
        }
    }

    IEnumerator PlayParticles()
    {
        particle.Play();
        yield return new WaitForSeconds(5f);

        particle.Stop();
        activeScare = false;
    }
}
