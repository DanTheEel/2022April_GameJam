using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Detection : MonoBehaviour
{
    public bool isBeingDetected = false;
    public NPC_Behavior npcBehavior;
    public Collider2D Cone;
    public LayerMask canDetect;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") /*&& isPlayerFirst(collision.ClosestPoint(this.transform.position))*/)
        {
            //Debug.Break();
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

    private bool isPlayerFirst(Vector2 otherPoint)
    {
        Vector2 thisV2Pos = new Vector2(this.transform.position.x, this.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, (thisV2Pos - otherPoint).normalized, 7, canDetect);
        Debug.DrawRay(this.transform.position, (otherPoint - thisV2Pos).normalized * 7, Color.red, 0.05f);
        if(hit.collider!=null)
        {
            Debug.Log($"did i hit the player... {hit.transform.name},{hit.transform.tag}");
            return (hit.transform.CompareTag("Player"));
        }
        return false;
    }
}
