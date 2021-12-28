using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardStatus : MonoBehaviour
{
    public bool OnGround;
    public bool OnRamp;
    public bool InAir;
    public bool OnGrindRail;

    private void Start()
    {
        InAir = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            OnGround = true;
            InAir = false;
        }
        else if (other.gameObject.tag == "Ramp")
        {
            OnRamp = true;
            InAir = false;
        }
        else if (other.gameObject.tag == "GrindRail")
        {
            OnGrindRail = true;
            InAir = false;
        }
        else if (other == null)
        {
            InAir = true;
        }
        else if(other.gameObject.tag == "Skateboard1" || other.gameObject.tag == "Skateboard2" || other.gameObject.tag == "Skateboard")
        {
            Debug.Log("Failure");
        }
        else
        {
            Debug.Log("UnknownTag Name: " + other.gameObject.tag);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            OnGround = false;
        }
        else if(other.gameObject.tag == "Ramp")
        {
            OnRamp = false;
        }
        else if(other.gameObject.tag == "GrindRail")
        {
            OnGrindRail = false;
        }

    }
}
