using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardGravity : MonoBehaviour
{
    Rigidbody rb;
    SkateboardStatus skateboardStatus;
    float RequiredGravity;
    Vector3 SourceOfGravity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        skateboardStatus = gameObject.GetComponentInChildren<SkateboardStatus>();
        RequiredGravity = 9.8f;
    }
    private void FixedUpdate()
    {// Set Gravitational force relative to the normal of the surface it is on
        if (skateboardStatus.InAir == true)
        {
            RequiredGravity = 9.8f;
            SourceOfGravity = Vector3.down;
        }
        else if(skateboardStatus.OnGrindRail == true)
        {

        }
        rb.AddForce(SourceOfGravity * rb.mass * RequiredGravity);
    }
}
