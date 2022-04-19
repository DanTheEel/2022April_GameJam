using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public bool isHiding = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiding = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        isHiding = false;
    }
}
