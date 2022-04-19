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


    public List<GameObject> NPCs;
    private void Start()
    {
        foreach(GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            NPCs.Add(npc);
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
