using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRailTrain : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Skateboard")
        other.gameObject.transform.position = transform.position;
        else
        {
            Debug.Log("Current Object is: " + other.gameObject);
        }
    }
}
