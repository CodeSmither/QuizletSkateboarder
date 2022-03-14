using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    SkateboardGravity skateboardGravity;
    SkateboardStatus skateboardStatus;
    Vector3 rampGravity;
    GameObject SourceOfBeginning;
    Rigidbody skateboardrb;
    GameObject Skateboard;
    bool isRotating = false;
    float turningTorque = 1.5f;
    
     
    
    private void Start()
    {
        skateboardGravity = GameObject.Find("Board").GetComponent<SkateboardGravity>();
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
        skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>(); 
        SourceOfBeginning = gameObject.transform.GetChild(0).gameObject;
        Skateboard = GameObject.Find("Board");
    }
    private void FixedUpdate()
    {
        
            skateboardGravity.SourceOfGravity = new Vector3(rampGravity.x, rampGravity.y, 0);

            if (isRotating == true)
            {
                Vector3 rightVec = new Vector3(Skateboard.transform.right.x, 0.0f, Skateboard.transform.right.z);
                if (Vector3.Dot(gameObject.transform.up, rightVec.normalized) >= 0.0f)
                {
                    skateboardrb.AddTorque(Skateboard.transform.up * turningTorque, ForceMode.Impulse);
                    skateboardrb.AddForce(gameObject.transform.up * (turningTorque * skateboardrb.velocity.magnitude), ForceMode.Impulse);
                }
                else
                {
                    skateboardrb.AddTorque(Skateboard.transform.up * -turningTorque, ForceMode.Impulse);
                    skateboardrb.AddForce(-gameObject.transform.up * (turningTorque * skateboardrb.velocity.magnitude), ForceMode.Impulse);
                }
            }
            //Vector3 CheckVec = new Vector3(Skateboard.transform.right.x, 0.0f, Skateboard.transform.right.z);
            //Debug.Log(Vector3.Dot(gameObject.transform.right, CheckVec.normalized));
            
    }
    private void OnTriggerStay(Collider other)
    {
        

            if (isRotating == true)
            {
                rampGravity = (SourceOfBeginning.transform.position - gameObject.transform.position).normalized;
                // makes forward direction part of a 2d Plane allowing it's direction to always be tracked
                Vector3 rightVec = new Vector3(Skateboard.transform.right.x, 0.0f, Skateboard.transform.right.z);
                float dot = Vector3.Dot(gameObject.transform.right, rightVec.normalized);
                if (dot >= 0.0f && skateboardrb.velocity.magnitude <= 4.0f)
                {
                    isRotating = true;
                }
                else if (dot <= 0.0f)
                {
                    isRotating = false;
                }
            }
        
    }
    private void OnTriggerExit(Collider other)
    {
        isRotating = false;
    }

}
