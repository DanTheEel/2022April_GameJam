using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetLoc = new Vector3(Target.position.x, Target.position.y, transform.position.z) ;

        transform.position = Vector3.Lerp(transform.position, TargetLoc, Time.deltaTime * followSpeed);
    }
}
