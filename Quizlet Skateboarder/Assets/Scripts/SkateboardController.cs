using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    Rigidbody rb;
    float torque = 2f;
    float speed = 3f;
    public bool OnGround;
    public bool OnRamp;
    public bool InAir;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("Flipback",0f);
        
    }

    void Update()
    {
        float turn = Input.GetAxisRaw("Horizontal");
        float move = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(move, 0, -turn);
        Vector3 Movement = rb.rotation * Direction.normalized;
        Quaternion BonusRotation = Quaternion.Euler(0,turn * 45, 0);
        Debug.Log(move);
        if (rb.velocity.sqrMagnitude < 0.01f)
        {
            rb.AddTorque(transform.up * torque * turn, ForceMode.Impulse);
            rb.AddForce(transform.right * speed * move, ForceMode.Impulse);
            
        }
        else
        {   // Vector 2 needed for complex direction
            //rb.AddForce(transform.right * speed * move, ForceMode.Impulse);
            rb.AddForce(Movement * speed * move, ForceMode.Acceleration);
            rb.rotation = Quaternion.Slerp(rb.rotation, rb.rotation * BonusRotation , Time.deltaTime);
            if (move < 0)
            {
                StartCoroutine("SlowDown");
            }
        }

        if (OnRamp == false)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
        }

        if (Input.GetKeyDown("space"))
        {
            Jumping();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            OnGround = true;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            OnGround = false;
           
        }
    }
    

    void Flipback()
    {
        
        float CurrentPositionx = transform.rotation.eulerAngles.x;
        float CurrentPositionz = transform.rotation.eulerAngles.z;

        if ((-90 > CurrentPositionz || -90 > CurrentPositionx || 90 < CurrentPositionz || 90 < CurrentPositionx) && OnGround == true)
        {
            rb.AddForce(-transform.up * 100f);
            gameObject.transform.Rotate(-CurrentPositionx, 0f, -CurrentPositionz, Space.Self);

        }
        Invoke("Flipback", 5f);
    }

    void Jumping()
    {
        rb.AddForce(transform.up * speed * 50, ForceMode.Impulse);
    }

    IEnumerator SlowDown()
    {
        if (InAir == false)
        {
            rb.velocity = rb.velocity * 0.95f;
            yield return new WaitForSeconds(0.5f);
            rb.velocity = rb.velocity * 0.95f;
            if (rb.velocity.magnitude > 0.01f)
            {
                rb.velocity = Vector3.zero;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
