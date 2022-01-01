using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRailTrain : MonoBehaviour
{
    private bool LockOn;
    Rigidbody Skateboardrb;
    NewSkateboardController newSkateboardController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skateboard")
        {
            LockOn = true;
        }
    }
    private void Start()
    {
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        newSkateboardController = Skateboardrb.gameObject.GetComponent<NewSkateboardController>();
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
