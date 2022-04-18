using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior : MonoBehaviour
{
    public List<Transform> waypoints;
    int waypointIndex = 0;

    public float waitingTime = 5;
    float waitingTimeLeft = 0;

    PathFinding pathFinding;

    void Start()
    {
        pathFinding = GetComponent<PathFinding>();
    }

    void Update()
    {
        if(pathFinding.IsAtDestination())
        {
            if (waitingTimeLeft <= 0)
            {
                MoveToWaypoint(waypointIndex);
                waypointIndex++;

                if(waypointIndex >= waypoints.Count)
                {
                    waypointIndex = 0;
                }

                waitingTimeLeft = waitingTime;
            }
            else
            {
                waitingTimeLeft -= Time.deltaTime;
            }
        }
    }

    public void MoveToWaypoint(int index)
    {
        pathFinding.endObj = waypoints[index];
    }

}
