using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    SkateboardGravity skateboardGravity;
    Vector3 rampGravity;
    GameObject SourceOfGravity;
    GameObject SourceOfBeginning;
    Rigidbody skateboardrb;
     
    
    private void Start()
    {
        skateboardGravity = GameObject.Find("Board").GetComponent<SkateboardGravity>();
        skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>(); 
        SourceOfGravity = gameObject.transform.GetChild(0).gameObject;
        SourceOfBeginning = gameObject.transform.GetChild(1).gameObject;
    }
    private void FixedUpdate()
    {
        skateboardGravity.SourceOfGravity = new Vector3(rampGravity.x,rampGravity.y,0);
    }
    private void OnTriggerStay(Collider other)
    {
        if (skateboardrb.velocity.magnitude > 2f)
        {
            rampGravity = (SourceOfGravity.transform.position - gameObject.transform.position).normalized;
        }
        else
        {
            rampGravity = (SourceOfBeginning.transform.position - gameObject.transform.position).normalized;
        }
        
    }
    
}
