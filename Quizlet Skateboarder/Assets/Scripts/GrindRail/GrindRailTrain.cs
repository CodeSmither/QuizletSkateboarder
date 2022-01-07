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
                }
                else if (Vector3.Dot(Skateboardrb.transform.right,GridRail.transform.right) > 0)
                {
                    Direction = "South";
                }
            }
            
            

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
