using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerInteractions : MonoBehaviour
{
    public float interactionCooldown = 0.05f;
    public List<GameObject> nearestObjects = new List<GameObject>();
    //private float timeLeft;
    private GameObject closest;
    public GameObject interactionUI;

    private void Start()
    {
        //timeLeft = interactionCooldown;
        //interactionUI.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.E) && closest != null && !Distraction_System.instance.AreTheyDistracted())
        {
            closest.GetComponent<IInteractable>().interact();
            Debug.Log("Interacted with object");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Interactable"))
        {          
            nearestObjects.Add(other.gameObject);
            //interactionUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("Interactable"))
        {
            nearestObjects.Remove(other.gameObject);
            closest = null;
            //interactionUI.SetActive(false);
        }
    }
}
