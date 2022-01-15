using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardStatus : MonoBehaviour
{
    public bool OnGround;
    public bool OnRamp;
    public bool InAir;
    public bool OnGrindRail;
    public bool RampAir;
    public bool LockOn;
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
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            OnGround = false;
            InAir = true;
        }
        else if(other.gameObject.tag == "Ramp")
        {
            OnRamp = false;
            InAir = true;
        }
        else if(other.gameObject.tag == "GrindRail")
        {
            OnGrindRail = false;
            InAir = true;
        }

    }
}
