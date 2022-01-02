using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampDecision : MonoBehaviour
{
    bool RampOver = false;
    NewSkateboardController newSkateboardController;
    Rigidbody Skateboardrb;
    RampAir rampAir;

    private void Start()
    {
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        newSkateboardController = Skateboardrb.gameObject.GetComponent<NewSkateboardController>();
        rampAir = gameObject.GetComponentInParent<RampAir>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (RampOver == false)
        {
            newSkateboardController.rampDecision = true;
            Quaternion q = Quaternion.FromToRotation(Skateboardrb.transform.right, Vector3.down) * Skateboardrb.transform.rotation;
            Skateboardrb.rotation = Quaternion.Slerp(Skateboardrb.transform.rotation, q, Time.deltaTime * 3.0f);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (RampOver == false)
        {
            StartCoroutine("EnableLanding");
        }
    }

    IEnumerator EnableLanding()
    {
        rampAir.InforLanding = true;
        yield return new WaitForSeconds(1.5f);
        rampAir.InforLanding = false;
    }
}
