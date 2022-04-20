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

    public bool AreTheyDistracted()
    {
        bool distracted = false;


        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponent<NPC_Behavior>().distracted)
            {
                distracted = true;
            }
        }

        return distracted;
    }

    public void ActivateDistraction(Transform distraction)
    {
        if(AreTheyDistracted())
        {
            foreach (GameObject npc in NPCs)
            {
                npc.GetComponent<NPC_Behavior>().Distract(distraction);
            }
        }
        foreach(GameObject npc in NPCs)
        {
            if(!npc.GetComponent<NPC_Behavior>().triggered)
            {
                npc.GetComponent<NPC_Behavior>().Distract(distraction);
            }
        }
    }
    public void ActivateJumpScare()
    {
        foreach (GameObject npc in NPCs)
        {
            npc.GetComponent<NPC_Behavior>().JumpScare();
        }
    }

    private void Update()
    {
        Debug.Log("distracted " + AreTheyDistracted());
    }
}
