using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_System : MonoBehaviour
{
    // singleton class
    public static Waypoint_System instance;
    private void Awake()
    {
        instance = this;
    }


    public List<Transform> waypoints;
    public int currentWaypointIndex = 0;

    public Vector2 GetCurrentWaypoint()
    {
        return waypoints[currentWaypointIndex].position;
    }
}
