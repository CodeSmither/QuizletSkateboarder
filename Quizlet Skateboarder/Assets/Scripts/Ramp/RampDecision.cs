using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampDecision : MonoBehaviour
{
    bool RampOver = false;
    NewSkateboardController newSkateboardController;
    Rigidbody Skateboardrb;
    RampAir rampAir;
    GameObject RampObject;
    int RampLayer;
    

    private void Start()
    {
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        newSkateboardController = Skateboardrb.gameObject.GetComponent<NewSkateboardController>();
        rampAir = gameObject.GetComponentInParent<RampAir>();
        RampObject = gameObject.transform.parent.parent.gameObject;
        RampLayer = RampObject.gameObject.layer;
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (RampOver == false)
        {
            switch (RampLayer)
            {
                case 0:
                    Quaternion q = Quaternion.Euler(180f, Skateboardrb.rotation.y, 145f);
                    Skateboardrb.rotation = Quaternion.RotateTowards(Skateboardrb.rotation, q, 30f * Time.deltaTime);
                    break;
                case 9:
                    Quaternion x = Quaternion.Euler(0f, Skateboardrb.rotation.y, 325f);
                    Skateboardrb.rotation = Quaternion.RotateTowards(Skateboardrb.rotation, x, 30f * Time.deltaTime);
                    break;
                case 10:
                    Quaternion y = Quaternion.Euler(Skateboardrb.rotation.x, 270, 325f);
                    Skateboardrb.rotation = Quaternion.RotateTowards(Skateboardrb.rotation, y, 30f * Time.deltaTime);
                    break;
                case 11:
                    Quaternion z = Quaternion.Euler(Skateboardrb.rotation.x, 90, 145f);
                    Skateboardrb.rotation = Quaternion.RotateTowards(Skateboardrb.rotation, z, 30f * Time.deltaTime);
                    break;
                default:
                    return;
            }
            newSkateboardController.rampDecision = true;
            //Quaternion q = Quaternion.FromToRotation(Skateboardrb.transform.right, Vector3.down);
            //Skateboardrb.rotation = Quaternion.Lerp(Skateboardrb.transform.rotation, q, Time.deltaTime * 10.0f);

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (RampOver == false)
        {
            float smoothtime = 0.4f;
            Vector3 Velocity = Vector3.zero;
            switch (RampLayer)
            {
                case 0:
                    Skateboardrb.transform.position = Vector3.SmoothDamp(Skateboardrb.transform.position, Vector3.left * 0.2f * Skateboardrb.velocity.magnitude, ref Velocity, smoothtime);
                    break;
                case 9:
                    Skateboardrb.transform.position = Vector3.SmoothDamp(Skateboardrb.transform.position, Vector3.right * 0.2f * Skateboardrb.velocity.magnitude, ref Velocity, smoothtime);
                    break;
                case 10:
                    Skateboardrb.transform.position = Vector3.SmoothDamp(Skateboardrb.transform.position, Vector3.forward * 0.2f * Skateboardrb.velocity.magnitude, ref Velocity, smoothtime);
                    break;
                case 11:
                    Skateboardrb.transform.position = Vector3.SmoothDamp(Skateboardrb.transform.position, Vector3.back * 0.2f * Skateboardrb.velocity.magnitude, ref Velocity, smoothtime);
                    break;
                default:
                    return;
            }
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
