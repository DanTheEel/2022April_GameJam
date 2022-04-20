using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> interactables;

    public Transform roomWaypoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            interactables.Add(collision.gameObject);
        }

        if(collision.tag == "NPC")
        {
            collision.GetComponent<PathFinding>().pathfinding = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "NPC")
        {
            collision.GetComponent<PathFinding>().pathfinding = true;
        }
    }

    public bool IsInRoom(GameObject interactable)
    {
        return interactables.Contains(interactable);
    }

}
