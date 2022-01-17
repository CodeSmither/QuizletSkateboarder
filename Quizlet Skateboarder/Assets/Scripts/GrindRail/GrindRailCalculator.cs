using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRailCalculator : MonoBehaviour
{
    
    Rigidbody Skateboardrb;
    protected internal string Direction;
    GameObject GridRail;
    GameObject NorthNode;
    GameObject SouthNode;
    SkateboardStatus skateboardStatus;
    Vector3 Destination;
    
    

    public void Start()
    {
        
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        GridRail = gameObject.transform.parent.gameObject;
        NorthNode = GameObject.Find("North Node");
        SouthNode = GameObject.Find("South Node");
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Vector3.Dot(NorthNode.transform.position,Skateboardrb.velocity) > 0)
        {
            Direction = "North";
            Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 135f, Skateboardrb.transform.rotation.z);
        }
        else if (Vector3.Dot(SouthNode.transform.position, Skateboardrb.velocity) > 0)
        {
            Direction = "South";
            Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 315f, Skateboardrb.transform.rotation.z);
        }
        if (Vector3.Dot(Skateboardrb.transform.right, GridRail.transform.right) < 0)
        {
            Vector3 LineVector = (NorthNode.transform.position - SouthNode.transform.position).normalized;
            Vector3 Differenciation = (Skateboardrb.transform.position - SouthNode.transform.position);
            float t = Vector3.Dot(LineVector, Differenciation);
            Destination = SouthNode.transform.position + (LineVector * t);
            Skateboardrb.transform.position = Destination;
        }
        else if (Vector3.Dot(Skateboardrb.transform.right, GridRail.transform.right) > 0)
        {
            
            Vector3 LineVector = (SouthNode.transform.position - NorthNode.transform.position).normalized;
            Vector3 Differenciation = (Skateboardrb.transform.position - NorthNode.transform.position);
            float t = Vector3.Dot(LineVector, Differenciation);
            Destination = NorthNode.transform.position + (LineVector * t);
            Skateboardrb.transform.position = Destination;
        }
        skateboardStatus.OnGrindRail = true;
        skateboardStatus.InAir = false;
        skateboardStatus.LockOn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Direction = "";
        skateboardStatus.OnGrindRail = false;
        skateboardStatus.InAir = true;
    }
    
}
