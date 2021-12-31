using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRamp : MonoBehaviour
{
    Rigidbody skateboardrb;
    NewSkateboardController newSkateboardController;
    GameObject skateboard;

    private void Start()
    {
        skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        newSkateboardController = skateboardrb.gameObject.GetComponent<NewSkateboardController>();
        skateboard = skateboardrb.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skateboard")
        {
            Vector3 rightVec = new Vector3(skateboard.transform.right.x, 0.0f, skateboard.transform.right.z);
            if (Vector3.Dot(gameObject.transform.right, rightVec.normalized) >= 0.0f && Vector3.Dot(gameObject.transform.right, skateboardrb.velocity.normalized) >= 0.0f)
            {
                
                if (skateboardrb.velocity.magnitude > 4.0f)
                {
                    newSkateboardController.controlsDisabled = true;
                    Invoke("EnableControls", 3.0f);
                    skateboardrb.velocity = new Vector3(0.0f, 10.0f, 0.0f);
                    skateboardrb.rotation = Quaternion.Euler(0, skateboardrb.rotation.eulerAngles.y, 90);
                    skateboardrb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    StartCoroutine("ReAdjustments ")
                }
            }
        }
    }

    private void EnableControls()
    {
        newSkateboardController.controlsDisabled = false;
    }
}
