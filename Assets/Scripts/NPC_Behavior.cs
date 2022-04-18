using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior : MonoBehaviour
{
    public List<Transform> waypoints;
    int waypointIndex = 0;

    bool wandering = false;
    public float wanderingRadius = 2;
    Vector2 basePosition;

    public float waitingTime = 1;   // seconds
    float waitingTimeLeft = 0;

    PathFinding pathFinding;

    void Start()
    {
        pathFinding = GetComponent<PathFinding>();
        pathFinding.endObj.position = waypoints[waypointIndex].position;
        basePosition = waypoints[waypointIndex].position;
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
        pathFinding.endObj.position = (Random.insideUnitCircle * wanderingRadius) + basePosition;
    }

    [ContextMenu("Resume Patrole")]
    public void ResumePatrol()
    {
        wandering = false;

        waypointIndex++;
        pathFinding.endObj.position = waypoints[waypointIndex].position;
        basePosition = waypoints[waypointIndex].position;
    }

    public void MoveToWaypoint(int index)
    {
        pathFinding.endObj = waypoints[index];
    }

}
