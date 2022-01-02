using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampAir : MonoBehaviour
{
    SkateboardStatus skateboardStatus;
    private void Start()
    {
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
    }
    private void OnTriggerStay(Collider other)
    {
        skateboardStatus.RampAir = true;
    }
    private void OnTriggerExit(Collider other)
    {
        skateboardStatus.RampAir = false;
    }
}
