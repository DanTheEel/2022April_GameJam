using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearMeter : MonoBehaviour
{
    // singleton class => call it with => FearMeter.instance
    public static FearMeter instance;
    private void Awake()
    {
        instance = this;
    }


    public float maxFear = 100;
    float currentFear = 0;

    public Image fearMeterFill;

    public void AddFear(float fear)
    {
        currentFear += fear;

        fearMeterFill.fillAmount = currentFear / maxFear;

        if (currentFear >= 100)
        {
            // win / end game !!!
            GameManager.instance.WinGame();

            Waypoint_System.instance.currentWaypointIndex = 4;
            foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
            {
                npc.GetComponent<NPC_Behavior>().ResumePatrol();
                npc.GetComponent<PathFinding>().pathfinding = true;
                npc.GetComponent<PathFinding>().moveSpeed = npc.GetComponent<NPC_Behavior>().fleeSpeed;
            }
        }
    }


    void Start()
    {
        currentFear = 0;
        fearMeterFill.fillAmount = currentFear / maxFear;
    }

    
}
