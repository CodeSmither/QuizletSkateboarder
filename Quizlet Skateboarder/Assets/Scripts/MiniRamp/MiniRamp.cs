using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRamp : MonoBehaviour
{
    Vector3 rampGravity;
    SkateboardGravity skateboardGravity;
    GameObject SourceOfBeginning;
    

    void Start()
    {
        skateboardGravity = GameObject.Find("Board").GetComponent<SkateboardGravity>();
        SourceOfBeginning = gameObject.transform.GetChild(3).gameObject;
    }
    private void OnTriggerStay(Collider other)
    {
        if(gameObject.tag == "Skateboard")
        {
            rampGravity = (SourceOfBeginning.transform.position - gameObject.transform.position).normalized;
            skateboardGravity.SourceOfGravity = new Vector3(rampGravity.x, rampGravity.y, 0);
        }
        
    }
    
}
