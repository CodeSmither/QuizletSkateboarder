using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRailEnd : MonoBehaviour
{
    SkateboardStatus skateboardStatus;
    void Start()
    {
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(skateboardStatus.LockOn == true)
        {
            skateboardStatus.LockOn = false;
        }
        
    }


}
