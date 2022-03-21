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
        // stores the skateboard Rigidbody
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        // stores the skateboard parent object
        GridRail = gameObject.transform.parent.gameObject;
        // stores both ends of the grindrail
        NorthNode = GameObject.Find("North Node");
        SouthNode = GameObject.Find("South Node");
        // stores a reference to the skateboard's current status
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        // checks where the skateboard is moving by checking which direction it is relative to
        if (Vector3.Dot(NorthNode.transform.position,Skateboardrb.velocity) > 0)
        {
            Direction = "North";
            Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 45f, Skateboardrb.transform.rotation.z);
        }
        else if (Vector3.Dot(SouthNode.transform.position, Skateboardrb.velocity) > 0)
        {
            Direction = "South";
            Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 225f, Skateboardrb.transform.rotation.z);
        }
        // checks if the skateboard is moving in the correct direction
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
        //lets skateboard status know that the skateboard is on the grindrail, locked on to the grind rail and not in the air
        skateboardStatus.OnGrindRail = true;
        skateboardStatus.InAir = false;
        skateboardStatus.LockOn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //clears the skateboard direction
        Direction = "";
        //lets the skateboard know it is no longer on the ramp
        skateboardStatus.OnGrindRail = false;
        skateboardStatus.InAir = true;
    }
    
}
