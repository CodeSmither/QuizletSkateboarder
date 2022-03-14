using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRail : MonoBehaviour
{
    GameObject GrindRailAgent;
    GameObject Skateboard;
    GameObject GrindRailScan;
    GameObject GrindRailSurface;
    GrindRailTrain GrindRailTrain;
    
    void Start()
    {
        GrindRailAgent = gameObject.transform.GetChild(0).gameObject;
        GrindRailScan = gameObject.transform.GetChild(1).gameObject;
        GrindRailSurface = this.gameObject;
        Skateboard = GameObject.Find("Board");
        GrindRailTrain = GrindRailAgent.GetComponent<GrindRailTrain>();
    }

    private void Update()
    {
        if (GrindRailTrain.LockOn == false)
        {
            if (Skateboard.transform.position.x < GrindRailAgent.transform.position.x + 13.5f && GrindRailAgent.transform.position.x - 13.5f < Skateboard.transform.position.x)
            {

                if (Skateboard.transform.position.z < GrindRailAgent.transform.position.z + 13.5f && GrindRailAgent.transform.position.z - 13.5f < Skateboard.transform.position.z)
                {
                    Quaternion colliderRotation = GrindRailSurface.GetComponent<BoxCollider>().transform.rotation;
                    Vector3 NearestPoint = Physics.ClosestPoint(Skateboard.transform.position, GrindRailSurface.GetComponent<BoxCollider>(), GrindRailSurface.GetComponent<BoxCollider>().transform.position, colliderRotation);
                    GrindRailAgent.transform.position = NearestPoint;
                }
            }
        }
        if (GrindRailTrain.LockOn == true)
        {
            if (GrindRailTrain.Direction == "North")
            {

            }
            else if (GrindRailTrain.Direction == "South")
            {

            }
        }
        
        
            
            
        
    }






}
