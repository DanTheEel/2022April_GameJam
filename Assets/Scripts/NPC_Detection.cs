using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Detection : MonoBehaviour
{
    bool isBeingDetected = false;
    public NPC_Behavior npcBehavior;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerHidingSystem.instance.hidden)
            {
                isBeingDetected = true;
            }
            else
            {
                isBeingDetected = false;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isBeingDetected = false;
        }
    }

    private void Update()
    {
        if(!npcBehavior.distracted)
        {
            if (isBeingDetected)
            {
                DetectionMeter.instance.SetDetection(true);
            }
            else
            {
                DetectionMeter.instance.SetDetection(false);
            }
        }
    }

}
