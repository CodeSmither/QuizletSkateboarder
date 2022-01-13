using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardGravity : MonoBehaviour
{
    public Rigidbody gravityrb;
    SkateboardStatus skateboardStatus;
    float RequiredGravity;
    public Vector3 SourceOfGravity;
    void Start()
    {
        gravityrb = GetComponent<Rigidbody>();
        skateboardStatus = gameObject.GetComponentInChildren<SkateboardStatus>();
        RequiredGravity = 9.8f;
    }
    private void FixedUpdate()
    {// Set Gravitational force relative to the normal of the surface it is on
        if (skateboardStatus.InAir == true)
        {
            RequiredGravity = 9.8f;
            SourceOfGravity = Vector3.down;
            gravityrb.constraints = RigidbodyConstraints.FreezeRotationX;
        }
        else if(skateboardStatus.OnGrindRail == true)
        {
            RequiredGravity = 0.0f;
            SourceOfGravity = Vector3.zero;
            gravityrb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else if (skateboardStatus.OnRamp == true)
        {
            RequiredGravity = 9.8f;
            gravityrb.constraints = RigidbodyConstraints.None;
            
            gravityrb.AddForce(Vector3.down * gravityrb.mass * RequiredGravity);
        }
        else if(skateboardStatus.OnGround == true)
        {
            RequiredGravity = 9.8f;
            SourceOfGravity = Vector3.down;
            gravityrb.constraints = RigidbodyConstraints.None;
        }
        gravityrb.AddForce(SourceOfGravity * gravityrb.mass * RequiredGravity);
    }
}
