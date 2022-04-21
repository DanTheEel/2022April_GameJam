using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInteraction : MonoBehaviour, IInteractable
{
    public AnimationTrigger anim;

    public ParticleSystem particle;
    private bool isTriggered = false;
    private bool activeScare = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
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

    public void interact()
    {
        //do something
        Debug.Log("interact");
        int i = Random.Range(1, 4);
        if (i.Equals(1))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(i.Equals(2))
        {
            GetComponent<SpriteRenderer>().color = Color.green;

        }
        else if(i.Equals(3))
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (Waypoint_System.instance.GetCurrentRoom().interactables.Contains(this.gameObject))
        {
            Distraction_System.instance.ActivateDistraction(this.transform);
            Distraction_System.instance.ActivateDistractionVisuals();
        }

    }
    public void Start()
    {
        if(this.gameObject.tag != "Interactable")
        {
            this.gameObject.tag = "Interactable";
        }
    }
}

