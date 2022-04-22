using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpscare : MonoBehaviour
{
    public float fearPerSpook = 25;

    List<GameObject> npcsInRange;

    
    public AudioSource vampireJumpScareAudioSource;
    public AudioClip vampireJumpscareClip;

    public Animator jumpscareAnim;

    private void Start()
    {
        npcsInRange = new List<GameObject>();

        vampireJumpScareAudioSource = transform.parent.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (npcsInRange.Count > 0)
            {
                if (Distraction_System.instance.AreTheyDistracted())
                {
                    Waypoint_System.instance.currentWaypointIndex++;
                    FearMeter.instance.AddFear(fearPerSpook);
                    Distraction_System.instance.ActivateJumpScare();

                    Camera.main.gameObject.GetComponent<Animator>().SetTrigger("Shake");
                    jumpscareAnim.SetTrigger("Jumpscare");
                    vampireJumpScareAudioSource.PlayOneShot(vampireJumpscareClip);
                }
            }
        }
        if(npcsInRange.Count > 0)
        {
            if(Distraction_System.instance.AreTheyDistracted())
            {
                InteractionUI.instance.SetText("F", true);

            }
            else
            {
                InteractionUI.instance.SetText("F", false);
            }
        }
        else
        {
            InteractionUI.instance.SetText("F", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NPC")
        {
            npcsInRange.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            npcsInRange.Remove(collision.gameObject);
        }
    }


    
}
