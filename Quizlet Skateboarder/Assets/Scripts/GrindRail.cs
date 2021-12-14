using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindRail : MonoBehaviour
{
    private bool LockOn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Skateboard")
        {
            LockOn = true;
            ConnectionFunc(collision);
            
        }
    }


    IEnumerator ConnectionFunc(Collision collision)
    {

        Transform collisionPosition = collision.gameObject.transform;

        //Quarterion collisionRotation = collision.GameObject.roation;


        if (LockOn == true)
        {
            if (collisionPosition.position.z < transform.position.z - 0.5f || collisionPosition.position.z > transform.position.z + 0.5f)
            {
                collisionPosition.position = new Vector3(collisionPosition.position.x, collisionPosition.position.y, transform.position.z);
            }
            if (collisionPosition.position.y < transform.position.y - 0.5f || collisionPosition.position.y > transform.position.y + 0.5f)
            {
                collisionPosition.position = new Vector3(collisionPosition.position.x, transform.position.y + 0.9f, collisionPosition.position.z);
            }
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ConnectionFunc(collision));
    }

        


}
