using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampAir : MonoBehaviour
{
    SkateboardStatus skateboardStatus;
    Rigidbody skateboardrb;
    public bool InforLanding = false;
    int RampLayer;
    GameObject RampObject;
    private void Start()
    {
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
        skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        RampObject = gameObject.transform.parent.gameObject;
        RampLayer = RampObject.gameObject.layer;
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        skateboardStatus.RampAir = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        skateboardStatus.RampAir = false;
         
    }
    private void Update()
    {
        if(InforLanding == true)
        {
            switch (RampLayer)
            {
                case 0:
                    skateboardrb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
                    break;
                case 9:
                    skateboardrb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
                    break;
                case 10:
                    skateboardrb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
                    break;
                case 11:
                    skateboardrb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
                    break;
                default:
                    break;
            }
            
        }
        
    }
}
