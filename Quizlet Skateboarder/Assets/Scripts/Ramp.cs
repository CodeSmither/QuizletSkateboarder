using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Skateboard")
        {
            collision.gameObject.GetComponent<SkateboardController>().OnRamp = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Skateboard")
        {
            collision.gameObject.GetComponent<SkateboardController>().OnRamp = false;
        }
    }
}
