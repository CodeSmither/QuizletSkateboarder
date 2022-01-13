using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRailCalculator : MonoBehaviour
{
    
    Rigidbody Skateboardrb;
    protected internal string Direction;
    GameObject GridRail;
    private float RailSpeed;
    GameObject NorthNode;
    GameObject SouthNode;
    SkateboardStatus skateboardStatus;

    public void Start()
    {
        
        Skateboardrb = GameObject.Find("Board").GetComponent<Rigidbody>();
        GridRail = gameObject.transform.parent.gameObject;
        NorthNode = GameObject.Find("North Node");
        SouthNode = GameObject.Find("South Node");
        skateboardStatus = GameObject.Find("Skateboard").GetComponent<SkateboardStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Vector3.Dot(Skateboardrb.transform.right, GridRail.transform.right) < 0)
        {
            Direction = "North";
            Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 135f, Skateboardrb.transform.rotation.z);
            RailSpeed = Skateboardrb.velocity.magnitude;
        }
        else if (Vector3.Dot(Skateboardrb.transform.right, GridRail.transform.right) > 0)
        {
            Direction = "South";
            Skateboardrb.transform.rotation = Quaternion.Euler(Skateboardrb.transform.rotation.x, 315f, Skateboardrb.transform.rotation.z);
        }
        skateboardStatus.OnGrindRail = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Direction = "";
    }

    private void FixedUpdate()
    {
        if(Direction == "North")
        {
            Vector3 Destination = new Vector3(NorthNode.transform.position.x, Skateboardrb.transform.position.y, NorthNode.transform.position.y);
            Skateboardrb.transform.position  = Vector3.MoveTowards(Skateboardrb.transform.position, Destination, RailSpeed);
        }
        else if (Direction == "South")
        {
            Vector3 Destination = new Vector3(SouthNode.transform.position.x, Skateboardrb.transform.position.y, SouthNode.transform.position.y);
            Skateboardrb.transform.position = Vector3.MoveTowards(Skateboardrb.transform.position, Destination, RailSpeed);
        }
    }

}
