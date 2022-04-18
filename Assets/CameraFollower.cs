using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    public float Smoothing = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetLoc = new Vector3(Target.position.x, Target.position.y, transform.position.z) ;
        Vector3 TargetVelocity = Target.GetComponent<Rigidbody2D>().velocity;
        transform.position = Vector3.SmoothDamp(transform.position, TargetLoc, Time.deltaTime * Smoothing); ;
    }
}
