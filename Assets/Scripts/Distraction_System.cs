using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction_System : MonoBehaviour
{
    //singleton class
    public static Distraction_System instance;
    private void Awake()
    {
        instance = this;
    }

    public Transform distractionTest;

    public List<GameObject> NPCs;
    private void Start()
    {
        foreach(GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            NPCs.Add(npc);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(NPCs[0].GetComponent<NPC_Behavior>().distracted)
            {
                Waypoint_System.instance.currentWaypointIndex++;
                FearMeter.instance.AddFear(25);
                ActivateJumpScare();
            }
            else
            {
                ActivateDistraction(distractionTest);
            }
        }
    }

    

    public void ActivateDistraction(Transform distraction)
    {
        foreach(GameObject npc in NPCs)
        {
            npc.GetComponent<NPC_Behavior>().Distract(distraction);
        }
    }
    public void ActivateJumpScare()
    {
        foreach (GameObject npc in NPCs)
        {
            npc.GetComponent<NPC_Behavior>().JumpScare();
        }
    }
}
