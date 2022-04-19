using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpscare : MonoBehaviour
{
    public float fearPerSpook = 25;
    GameObject npcInRange = null;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(npcInRange != null)
            {
                if(npcInRange.GetComponent<NPC_Behavior>().distracted)
                {
                    Waypoint_System.instance.currentWaypointIndex++;
                    FearMeter.instance.AddFear(fearPerSpook);
                    Distraction_System.instance.ActivateJumpScare();
                }
            }
        }

        if(npcInRange != null)
        {
            Debug.Log(npcInRange);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NPC")
        {
            if(npcInRange == null)
            {
                npcInRange = collision.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            npcInRange = null;
        }
    }
}
