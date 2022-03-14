using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp3 : MonoBehaviour
{
    SkateboardGravity skateboardGravity;
    SkateboardStatus skateboardStatus;
    Vector3 rampGravity;
    GameObject SourceOfBeginning;
    Rigidbody skateboardrb;
    float RampSpeed;
    float startingRotation;
    float startingPosition;
    GameObject skateboard;


    private void Start()
    {
        skateboardGravity = GameObject.Find("Board").GetComponent<SkateboardGravity>();
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
        skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        SourceOfBeginning = gameObject.transform.GetChild(1).gameObject;
        skateboard = skateboardrb.gameObject;

    }
    private void FixedUpdate()
    {
        
        skateboardGravity.SourceOfGravity = new Vector3(rampGravity.x, rampGravity.y, 0);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (skateboardrb.velocity.magnitude < 4f)
        {
            rampGravity = (SourceOfBeginning.transform.position - gameObject.transform.position).normalized;
            if (Vector3.Dot(gameObject.transform.forward, skateboard.transform.forward) <= 0)
            {
            
            }
            
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        rampGravity = Vector3.down;
    }
}
