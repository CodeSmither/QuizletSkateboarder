using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRailTrain : MonoBehaviour
{
    protected internal bool LockOn;
    Rigidbody Skateboardrb;
    NewSkateboardController newSkateboardController;
    GameObject GridRail;
    protected internal string Direction;
    GameObject Camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skateboard")
        {
            if (LockOn == false)
            {
                LockOn = true;
                if (Vector3.Dot(Skateboardrb.transform.right,GridRail.transform.right) < 0)
                {
                    Direction = "North";
                    Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 135f, Skateboardrb.transform.rotation.z);
                }
                else if (Vector3.Dot(Skateboardrb.transform.right,GridRail.transform.right) > 0)
                {
                    Direction = "South";
                    Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 315f, Skateboardrb.transform.rotation.z);
                }
            }
            
            

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (LockOn == true)
        {
            
        }
    }
    private void Start()
    {
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        newSkateboardController = Skateboardrb.gameObject.GetComponent<NewSkateboardController>();
        GridRail = gameObject.transform.parent.gameObject;
    }
    private void FixedUpdate()
    {
        if (LockOn == true)
        {
            Skateboardrb.gameObject.transform.position = gameObject.transform.position;
            newSkateboardController.controlsDisabled = true;
            Skateboardrb.constraints = RigidbodyConstraints.FreezePosition;
        }
        
        
    }
}
