using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerInteractions : MonoBehaviour
{
    public float interactionCooldown = 0.05f;
    private List<GameObject> nearestObjects = new List<GameObject>();
    //private float timeLeft;
    private GameObject closest;
    private void Start()
    {
        //timeLeft = interactionCooldown;
    }
    // Update is called once per frame
    void Update()
    {
        if (nearestObjects.Count == 1)
        {
            closest = nearestObjects.First();
        }        
        else if (nearestObjects.Count>=2)
        {
            var sorted = nearestObjects.OrderBy(obj => (obj.transform.position - transform.position).sqrMagnitude);
            closest = sorted.First();
        }
        if (Input.GetKeyDown(KeyCode.E) && closest != null)
        {
            closest.GetComponent<IInteractable>().interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            nearestObjects.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            nearestObjects.Remove(other.gameObject);
        }
    }
}
