using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkateboardController : MonoBehaviour
{
    Rigidbody rb;
    SkateboardStatus skateboardStatus;
    GameObject Camera;
    
    float torque = 2f;
    float speed = 3f;
    bool JumpReady = true;
    public bool controlsDisabled = false;
    bool DoingTrick = false;
    public bool rampDecision = false;
    float SkateboardMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        skateboardStatus = gameObject.GetComponentInChildren<SkateboardStatus>();
        Camera = gameObject.transform.GetChild(1).gameObject;
      
    }
    void Update()
    {
        if (controlsDisabled == false && skateboardStatus.InAir != true && skateboardStatus.LockOn == false)
        {
            Camera.transform.localPosition = new Vector3(-1.176285f, 0.41f, -0.3704104f);
            Camera.transform.localRotation = Quaternion.Euler(0,90,0);
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
        if (skateboardStatus.InAir == true && DoingTrick == false && skateboardStatus.RampAir == false && rampDecision == false)
        {
            Quaternion q = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5.0f);
            Camera.transform.localPosition = new Vector3(-1.176285f, 0.41f, -0.3704104f);
            Camera.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        if (skateboardStatus.LockOn == true)
        {
            Camera.transform.localPosition = new Vector3(-0.434f, 0.41f, 1.2f);
            Camera.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (skateboardStatus.OnGround == true)
        {
            controlsDisabled = false;
            if (Vector3.Dot(rb.transform.up, Vector3.down) >= 0.5f)
            {
                rb.transform.up = Vector3.up;
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
            rb.AddForce(transform.up * speed * 50, ForceMode.Impulse);  
    }
    
}
