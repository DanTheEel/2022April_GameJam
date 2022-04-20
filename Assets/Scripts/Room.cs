using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> interactables;

    public Transform roomWaypoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.tag == "Interactable")
        {
            interactables.Add(collision.gameObject);
        }
    }

    public bool IsInRoom(GameObject interactable)
    {
        return interactables.Contains(interactable);
    }

}
