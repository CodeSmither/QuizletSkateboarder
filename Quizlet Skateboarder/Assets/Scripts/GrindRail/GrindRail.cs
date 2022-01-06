using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRail : MonoBehaviour
{
    GameObject GrindRailAgent;
    GameObject Skateboard;
    GameObject GrindRailScan;
    
    void Start()
    {
        GrindRailAgent = gameObject.transform.GetChild(0).gameObject;
        GrindRailScan = gameObject.transform.GetChild(1).gameObject;
        Skateboard = GameObject.Find("Board");
    }

    private void Update()
    {
        if (Skateboard.transform.position.x < GrindRailAgent.transform.position.x + 13.5f && GrindRailAgent.transform.position.x - 13.5f < Skateboard.transform.position.x) 
        {
            
            if (Skateboard.transform.position.z < GrindRailAgent.transform.position.z + 13.5f && GrindRailAgent.transform.position.z - 13.5f < Skateboard.transform.position.z)
            {
                Quaternion colliderRotation = GrindRailScan.GetComponent<BoxCollider>().transform.rotation;  
                Vector3 NearestPoint = Physics.ClosestPoint(GrindRailScan.transform.position,GrindRailScan.GetComponent<BoxCollider>(),GrindRailScan.GetComponent<BoxCollider>().transform.position, colliderRotation);
                GrindRailAgent.transform.position = NearestPoint;
            }
        }
        
            
            
        
    }






}
