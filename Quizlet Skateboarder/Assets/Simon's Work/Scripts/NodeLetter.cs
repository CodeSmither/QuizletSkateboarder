using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLetter : MonoBehaviour
{
    public string letter;
    //stores the letter that this node collected from the game controller
    public GameObject GameManager;
    // stores a reference to the gameobject this is part of
    private bool cooling1;
    private bool cooling2;
    // stores if a cooldown has been set for player 1 and 2
    public int objectCount;
    // stores the current number of objects touching the point

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Skateboard1") && cooling1 == false)
        {// Checks if player 1 has entered the point and doesn't have a cooldown on their word
            
            GameManager.GetComponent<GameController>().player1spelling = GameManager.GetComponent<GameController>().player1spelling + letter;
            cooling1 = true;
            GameManager.GetComponent<GameController>().WordChecking1();
            StartCoroutine(CoolDownTimer());
            // Adds Letter to player 1
        }
        if (other.gameObject == GameObject.FindGameObjectWithTag("Skateboard2") && cooling2 == false)
        {// Checks if player 2 has entered the point and doesn't have a cooldown on their word

            GameManager.GetComponent<GameController>().player2spelling = GameManager.GetComponent<GameController>().player2spelling + letter;
            cooling2 = true;
            GameManager.GetComponent<GameController>().WordChecking2();
            StartCoroutine(CoolDownTimer());
            // Adds Letter to player 2
        }
        objectCount++;
        //increases the object count

    }
    private void OnTriggerExit(Collider other)
    {
        objectCount--;
        //decreases the object count when leaving the node
    }

    IEnumerator CoolDownTimer()
    {
        if (objectCount == 0)
        {
            yield return new WaitForSeconds(1f);
            cooling1 = false;
            cooling2 = false;
            // turns cooldowns off after 1 second
        }
        else if(cooling1 == true || cooling2 == true)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(CoolDownTimer());
            // if cooldown hasn't been turned off but doesn't have the conditions to turn off it restarts the Coroutine
        }
    }

}
