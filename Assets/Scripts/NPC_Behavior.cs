using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior : MonoBehaviour
{
    bool wandering = false;
    public float wanderingRadius = 2;
    Vector2 basePosition;

    public float waitingTime = 1;   // seconds
    float waitingTimeLeft = 0;

    PathFinding pathFinding;
    public Transform NPC_Target;
    public GameObject npcTargetPrefab;

    void Start()
    {
        pathFinding = GetComponent<PathFinding>();
        GameObject instantiatedPrefab = GameObject.Instantiate(npcTargetPrefab);
        NPC_Target = instantiatedPrefab.transform;
        pathFinding.endObj = NPC_Target;
        NPC_Target.position = Waypoint_System.instance.GetCurrentWaypoint();
        basePosition = Waypoint_System.instance.GetCurrentWaypoint();
    }

    void Update()
    {

        if(pathFinding.IsAtDestination())
        {
            if(wandering)
            {
                waitingTimeLeft -= Time.deltaTime;
            }
            else
            {
                Wander();
            }
        }

        if(waitingTimeLeft <= 0)
        {
            wandering = true;
            waitingTimeLeft = waitingTime;
            Wander();
        }

    }

    public void Wander()
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        Debug.Log(randomPoint);
        NPC_Target.position = (randomPoint * wanderingRadius) + basePosition;
    }

    [ContextMenu("Resume Patrol")]
    public void ResumePatrol()
    {
        wandering = false;

        Waypoint_System.instance.currentWaypointIndex++;
        NPC_Target.position = Waypoint_System.instance.GetCurrentWaypoint();
        basePosition = Waypoint_System.instance.GetCurrentWaypoint();
    }

   

}
