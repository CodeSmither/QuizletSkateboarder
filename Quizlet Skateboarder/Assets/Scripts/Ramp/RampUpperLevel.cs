using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampUpperLevel : MonoBehaviour
{
    GameObject Ramp;
    public PhysicMaterial BaseMaterial; 
    public PhysicMaterial RampMaterial;
    

    private void Start()
    {
        Ramp = gameObject.transform.parent.gameObject;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Skateboard")
        {
            Ramp.transform.GetChild(0).gameObject.SetActive(false);
            Ramp.transform.GetChild(1).gameObject.SetActive(false);
            Ramp.transform.GetChild(2).gameObject.SetActive(false);
            Ramp.GetComponent<Ramp>().enabled = false;
            Debug.Log("OnTop");
            Ramp.GetComponent<MeshCollider>().material = BaseMaterial;
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Ramp.transform.GetChild(0).gameObject.SetActive(true);
        Ramp.transform.GetChild(1).gameObject.SetActive(true);
        Ramp.transform.GetChild(2).gameObject.SetActive(true);
        Ramp.GetComponent<Ramp>().enabled = true;
        Ramp.GetComponent<MeshCollider>().material = RampMaterial;
        if(other.tag == "Skateboard")
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        }
        
    }
}
