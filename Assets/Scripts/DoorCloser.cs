using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    private float offset = 1;
    private float Speed;
    private new HingeJoint2D hingeJoint;
    public AudioSource audioSource;
    private bool hasPlayed = true;
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
        var centerAngle = (hingeJoint.limits.min + hingeJoint.limits.max) / 2;


        if (hingeJoint.jointAngle < centerAngle - offset)
        {
           //Debug.Log("transform.rotation.eulerAngles.z < -0.1 " + (transform.rotation.z) + (transform.rotation.z < -0.1));
            hingeJoint.useMotor = true;
            var motor = hingeJoint.motor;

            motor.motorSpeed = Speed;
            hingeJoint.motor = motor;

            hasPlayed = false;
            //creeky door?

        }
        else if (hingeJoint.jointAngle > centerAngle + offset)
        {
            //Debug.Log("transform.rotation.z > 0.1 " + (transform.rotation.z) + (transform.rotation.z > 0.1));
            hingeJoint.useMotor = true;
            var motor = hingeJoint.motor;

            motor.motorSpeed = -Speed;
            hingeJoint.motor = motor;

            hasPlayed = false;
            //creeky door?
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            hingeJoint.useMotor = false;
            if(!audioSource.isPlaying && !hasPlayed)
            {
                audioSource.Play();
                hasPlayed = true;
            }
               
        }
        //GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.one * forceStrength,GetComponent<HingeJoint2D>().anchor);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //play open clip?
    }
}
