using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRailEndPoint : MonoBehaviour
{
    Rigidbody Skateboardrb;
    NewSkateboardController newSkateboardController;
    GameObject GridRail;

    public void OnTriggerEnter(Collider other)
    {
        
    }

    private void Start()
    {
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        newSkateboardController = Skateboardrb.gameObject.GetComponent<NewSkateboardController>();
        GridRail = gameObject.transform.parent.gameObject;
    }
}
