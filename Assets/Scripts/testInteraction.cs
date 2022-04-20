using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInteraction : MonoBehaviour, IInteractable
{
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

