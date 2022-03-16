using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera Camera1;
    private CinemachineVirtualCamera Camera2;
    private CinemachineVirtualCamera Camera3;
    [SerializeField] private int currentviewstate;


    private void Start()
    {
        currentviewstate = 1;
        Camera1 = GameObject.Find("Camera 1").GetComponent<CinemachineVirtualCamera>();
        Camera2 = GameObject.Find("Camera 2").GetComponent<CinemachineVirtualCamera>();
        Camera3 = GameObject.Find("Camera 3").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentviewstate)
        {
            case 1:
                Prio1();
                break;
            case 2:
                Prio2();
                break;
            case 3:
                Prio3();
                break;
        }
    }

    private void Prio1()
    {
        Camera1.m_Priority = 10;
        Camera2.m_Priority = 9;
        Camera3.m_Priority = 9;
    }
    private void Prio2()
    {
        Camera1.m_Priority = 9;
        Camera2.m_Priority = 10;
        Camera3.m_Priority = 9;
    }
    private void Prio3()
    {
        Camera1.m_Priority = 9;
        Camera2.m_Priority = 9;
        Camera3.m_Priority = 10;
    }

    public void ChangePrio(int Prio)
    {
        currentviewstate = Prio;
    }
}
