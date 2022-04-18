using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Detection : MonoBehaviour
{
    bool isBeingDetected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isBeingDetected = true;
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
        if(isBeingDetected)
        {
            DetectionMeter.instance.SetDetection(true);
        }
        else
        {
            DetectionMeter.instance.SetDetection(false);
        }
    }

}
