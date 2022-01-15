using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampAir : MonoBehaviour
{
    SkateboardStatus skateboardStatus;
    Rigidbody skateboardrb;
    public bool InforLanding = false; 
    private void Start()
    {
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
        skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        skateboardStatus.RampAir = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        skateboardStatus.RampAir = false;

        //if (InforLanding == true)
       // {
       //     skateboardrb.AddTorque(Vector3.right * 5f, ForceMode.Impulse);
       // } 
    }
    private void Update()
    {
        
    }
}
