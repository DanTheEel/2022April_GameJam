using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    private float Speed;
    private new HingeJoint2D hingeJoint;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        Speed = hingeJoint.motor.motorSpeed;
        hingeJoint.useMotor = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.rotation.z < -0.01)
        {
           //Debug.Log("transform.rotation.eulerAngles.z < -0.1 " + (transform.rotation.z) + (transform.rotation.z < -0.1));
            hingeJoint.useMotor = true;
            var motor = hingeJoint.motor;

            motor.motorSpeed = -Speed;
            hingeJoint.motor = motor;

        }
        else if (transform.rotation.z > 0.01)
        {
           // Debug.Log("transform.rotation.z > 0.1 " + (transform.rotation.z) + (transform.rotation.z > 0.1));
            hingeJoint.useMotor = true;
            var motor = hingeJoint.motor;

            motor.motorSpeed = Speed;
            hingeJoint.motor = motor;

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            hingeJoint.useMotor = false;
        }
        //GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.one * forceStrength,GetComponent<HingeJoint2D>().anchor);
    }
}
