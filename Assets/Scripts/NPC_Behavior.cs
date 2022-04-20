using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior : MonoBehaviour
{
    bool wandering = false;
    public float wanderingRadius = 2;
    Vector2 basePosition;
    public float defaultSpeed = 2.5f;

    public float waitingTime = 1;   // seconds
    float waitingTimeLeft = 0;

    PathFinding pathFinding;
    public Transform NPC_Target;
    public GameObject npcTargetPrefab;

    public Transform fleePoint;
    public float fleeingTime = 2f;  // seconds
    public float fleeSpeed = 5;

    public bool distracted = false;
    bool triggered = false;
    public float gatheringRadius = 3f;

    void Start()
    {
        pathFinding = GetComponent<PathFinding>();
        GameObject instantiatedPrefab = GameObject.Instantiate(npcTargetPrefab);
        NPC_Target = instantiatedPrefab.transform;
        pathFinding.endObj = NPC_Target;
        NPC_Target.position = Waypoint_System.instance.GetCurrentWaypoint();
        basePosition = Waypoint_System.instance.GetCurrentWaypoint();
        pathFinding.moveSpeed = defaultSpeed;
    }

    void Update()
    {
        if(!triggered)
        {
            if (pathFinding.IsAtDestination())
            {
                if (wandering)
                {
                    waitingTimeLeft -= Time.deltaTime;
                }
                else
                {
                    Wander();
                }
            }

            if (waitingTimeLeft <= 0)
            {
                wandering = true;
                waitingTimeLeft = waitingTime;
                Wander();
            }
        }
        else
        {
            if (pathFinding.IsAtDestination())
            {
                distracted = true;
            }
        }
       
    }

    public void Wander()
    {
        pathFinding.moveSpeed = defaultSpeed;
        Vector2 randomPoint = Random.insideUnitCircle;
        NPC_Target.position = (randomPoint * wanderingRadius) + basePosition;
    }

    [ContextMenu("Resume Patrol")]
    public void ResumePatrol()
    {
        wandering = false;

        pathFinding.moveSpeed = defaultSpeed;
        NPC_Target.position = Waypoint_System.instance.GetCurrentWaypoint();
        basePosition = Waypoint_System.instance.GetCurrentWaypoint();
    }

   public void Distract(Transform distraction)
    {
        triggered = true;
        NPC_Target.position = distraction.position + (Random.insideUnitSphere * gatheringRadius);
    }

    public void JumpScare()
    {
        NPC_Target.position = fleePoint.position + (Random.insideUnitSphere * gatheringRadius);
        StartCoroutine(Flee());
    }

    public IEnumerator Flee()
    {
        pathFinding.moveSpeed = fleeSpeed;

        yield return new WaitForSeconds(fleeingTime);
        distracted = false;
        triggered = false;
        ResumePatrol();
    }

}
