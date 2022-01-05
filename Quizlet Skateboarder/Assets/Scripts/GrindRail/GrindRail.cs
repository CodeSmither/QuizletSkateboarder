using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRail : MonoBehaviour
{
    GameObject GrindRailAgent;
    GameObject Skateboard;
    void Start()
    {
        GrindRailAgent = gameObject.transform.GetChild(0).gameObject;
        Skateboard = GameObject.Find("Board");
    }

    private void Update()
    {
        if (Skateboard.transform.position.x < GrindRailAgent.transform.position.x + 13.5f && GrindRailAgent.transform.position.x - 13.5f < Skateboard.transform.position.x)
        {
            float x = Skateboard.transform.position.x;
            if (Skateboard.transform.position.z < GrindRailAgent.transform.position.z + 13.5f && GrindRailAgent.transform.position.z - 13.5f < Skateboard.transform.position.z)
            {
                float z = Skateboard.transform.position.z;

            }
        }
    }






}
