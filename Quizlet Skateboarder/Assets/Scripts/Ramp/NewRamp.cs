using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRamp : MonoBehaviour
{
    Rigidbody skateboardrb;
    NewSkateboardController newSkateboardController;
    GameObject skateboard;
    RampAir rampAir;

    private void Start()
    {
        skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        newSkateboardController = skateboardrb.gameObject.GetComponent<NewSkateboardController>();
        skateboard = skateboardrb.gameObject;
        rampAir = gameObject.transform.parent.GetChild(3).gameObject.GetComponent<RampAir>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skateboard")
        {
            Vector3 rightVec = new Vector3(skateboard.transform.right.x, 0.0f, skateboard.transform.right.z);
            if (Vector3.Dot(gameObject.transform.right, rightVec.normalized) >= 0.0f && Vector3.Dot(gameObject.transform.right, skateboardrb.velocity.normalized) >= 0.0f)
            {
                
                if (skateboardrb.velocity.magnitude > 4.0f && rampAir.InforLanding == false)
                {
                    newSkateboardController.controlsDisabled = true;
                    Invoke("EnableControls", 3.0f);
                    skateboardrb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    skateboardrb.velocity = new Vector3(0f, 10.0f, 0.0f);
                    skateboardrb.rotation = Quaternion.Euler(0, skateboardrb.rotation.eulerAngles.y, 90) * Quaternion.Euler(0,this.gameObject.transform.parent.rotation.y,0);
                    
                    
                }
            }
        }
    }

    private void EnableControls()
    {
        newSkateboardController.controlsDisabled = false;
    }

}
