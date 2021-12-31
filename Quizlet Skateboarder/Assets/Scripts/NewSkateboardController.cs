using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkateboardController : MonoBehaviour
{
    Rigidbody rb;
    SkateboardStatus skateboardStatus;
    
    float torque = 2f;
    float speed = 3f;
    bool JumpReady = true;
    public bool controlsDisabled = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        skateboardStatus = gameObject.GetComponentInChildren<SkateboardStatus>();
      
    }
    void Update()
    {
        if (controlsDisabled == false)
        {
            float turn = Input.GetAxisRaw("Horizontal");
            float move = Input.GetAxisRaw("Vertical");
            Vector3 Direction = new Vector3(move, 0, -turn);
            Vector3 Movement = rb.rotation * Direction.normalized;
            Quaternion BonusRotation = Quaternion.Euler(0, turn * 45, 0);

            if (rb.velocity.sqrMagnitude < 0.01f)
            {
                rb.AddTorque(transform.up * torque * turn, ForceMode.Impulse);
                rb.AddForce(transform.right * speed * move, ForceMode.Impulse);

            }
            else
            {   // Vector 2 needed for complex direction
                //rb.AddForce(transform.right * speed * move, ForceMode.Impulse);
                rb.AddForce(Movement * speed * move, ForceMode.Acceleration);
                rb.rotation = Quaternion.Slerp(rb.rotation, rb.rotation * BonusRotation, Time.deltaTime);
                if (move < 0)
                {
                    StartCoroutine("SlowDown");
                }
            }
            if (Input.GetKeyDown("space"))
            {
                Jumping();
            }
        }
    }
    IEnumerator SlowDown()
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
    void Jumping()
    {
        if (JumpReady == true)
        {
            rb.AddForce(transform.up * speed * 50, ForceMode.Impulse);
            StartCoroutine("JumpCoolDown");
        }
    }
    IEnumerator JumpCoolDown()
    {
        JumpReady = false;
        yield return new WaitForSeconds(5f);
        if (skateboardStatus)
        {
            JumpReady = true;
        }
    }
    
}
