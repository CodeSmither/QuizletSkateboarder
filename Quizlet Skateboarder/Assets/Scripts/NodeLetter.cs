using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLetter : MonoBehaviour
{
    public string letter;

    public GameObject GameManager;
    public bool cooling1;
    public bool cooling2;
    public int objectCount;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Skateboard1") && cooling1 == false)
        {
            Debug.Log("Touching");
            GameManager.GetComponent<GameController>().player1spelling = GameManager.GetComponent<GameController>().player1spelling + letter;
            cooling1 = true;
            GameManager.GetComponent<GameController>().WordChecking1();
            StartCoroutine(CoolDownTimer());
        }
        if (other.gameObject == GameObject.FindGameObjectWithTag("Skateboard2") && cooling1 == false)
        {
            Debug.Log("Touching");
            GameManager.GetComponent<GameController>().player1spelling = GameManager.GetComponent<GameController>().player2spelling + letter;
            cooling2 = true;
            GameManager.GetComponent<GameController>().WordChecking2();
            StartCoroutine(CoolDownTimer());
        }
        objectCount++;

    }
    private void OnTriggerExit(Collider other)
    {
        objectCount--;
    }

    IEnumerator CoolDownTimer()
    {
        if (objectCount == 0)
        {
            yield return new WaitForSeconds(1f);
            cooling1 = false;
            cooling2 = false;
        }
        else if(cooling1 == true || cooling2 == true)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(CoolDownTimer());
        }
    }
}
