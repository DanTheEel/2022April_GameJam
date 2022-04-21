using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpscare : MonoBehaviour
{
    public float fearPerSpook = 25;

    List<GameObject> npcsInRange;

    public Animator jumpscareAnim;

    private void Start()
    {
        npcsInRange = new List<GameObject>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
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
                }
            }
        }
        if(npcsInRange.Count > 0)
        {
            if(Distraction_System.instance.AreTheyDistracted())
            {
                InteractionUI.instance.SetText("Scare \nE", true);

            }
            else
            {
                InteractionUI.instance.SetText("Scare \nE", false);
            }
        }
        else
        {
            InteractionUI.instance.SetText("Scare \nE", false);
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
