using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardCentreOfMass : MonoBehaviour
{
    Rigidbody Skateboardrb;
    public Vector3 CentreOfMass;

    private void Start()
    {
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CentreOfMass = new Vector3(-0.15f, 0.03f, 0);
        Skateboardrb.centerOfMass = CentreOfMass;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * CentreOfMass, 0.01f);
    }
}
