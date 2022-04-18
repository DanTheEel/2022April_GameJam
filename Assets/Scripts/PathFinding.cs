using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Transform startObj;  //the object
    public Transform endObj;  //the target

    public float moveSpeed = 10;
    public float rotationSpeed;

    public GridManager grid;

    Rigidbody2D myRB;

    List<Node> path;
    List<Node> openSet;
    List<Node> closedSet;

    int travelPoint = 1;



    public GameObject body;




    //aggro or triggered movement
    public bool triggered = true;  //triggered is set as public to allow the level designer to turn it on and off

    private void Awake()
    {
        if (endObj != null) gameObject.SetActive(true);
    }

    private void Start()
    {
        startObj = transform;
        path = new List<Node>();
        openSet = new List<Node>();
        closedSet = new List<Node>();
        myRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        //The code below is used to move the start object along the path to the end object.
        if (endObj != null && grid != null && triggered)  //triggered is added as a condition to move.
        {
            // if in the same node, just move towards the target
            if(SameNode(transform , endObj))
            {
                myRB.AddForce(moveSpeed * 10 * (endObj.transform.position - transform.position));
            }

            if (startObj.position != endObj.position)
                FindPath(startObj.position, endObj.position);
            //else
            if (path.Count > 1 && travelPoint <= path.Count)
            {
                //move towards target
                if (grid.NodeFromWorldPoint(transform.position) == path[travelPoint])
                {
                    travelPoint++;
                }
                myRB.AddForce(moveSpeed * ((path[travelPoint].worldPosition) - transform.position));
            }
            else myRB.velocity = Vector2.zero;
        }


        // movement rotation
        if(endObj != null && body != null)
        {
            body.transform.up = Vector3.Lerp(body.transform.up, endObj.position - body.transform.position, rotationSpeed * Time.deltaTime);
        }


    }

    //public function SetTarget allows for the target to be changed.
    public void SetTarget(Transform theTarget)
    {
        endObj = theTarget;
    }

    public void RemoveTarget()
    {
        endObj = null;
    }

    public void SetGrid(GridManager theGrid)
    {
        grid = theGrid;
    }

    // if two objects are in the same node
    public bool SameNode(Transform A , Transform B)
    {
        return GetHCost(grid.NodeFromWorldPoint(A.position), grid.NodeFromWorldPoint(B.position)) <= 14;
    }


    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        if (!targetNode.traversable) return;


        path.Clear();
        travelPoint = 1;

        openSet.Clear();
        closedSet.Clear();

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    GetPath(startNode, targetNode);
                    return;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (closedSet.Contains(neighbour) || !neighbour.traversable)
                    {
                        continue;
                    }

                    
                    int moveCostToNext = currentNode.gCost + GetHCost(currentNode, neighbour);
                    if(moveCostToNext < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = moveCostToNext;
                        neighbour.hCost = GetHCost(neighbour, targetNode);
                        neighbour.parentNode = currentNode;

                        if (!openSet.Contains(neighbour)) openSet.Add(neighbour);
                    }
                }
            }

        

        }
    }

    void GetPath(Node startNode, Node endNode)
    {
        path.Clear();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parentNode;
        }

        path.Reverse();

        //remove below...visual demonstration in editor only.
        grid.path = path;

    }




    int GetHCost(Node nodeA, Node nodeB)
    {
        //find minimum diagonal distance to be on same level as target, then move horizontally or vertically to target
        int distX = Mathf.Abs((int)nodeA.gridLocation.x - (int)nodeB.gridLocation.x);
        int distY = Mathf.Abs((int)nodeA.gridLocation.y - (int)nodeB.gridLocation.y);

        if (distX > distY) return 14 * distY + 10*(distX - distY);
        else return 14 * distX + 10*(distY - distX);
    }

}
