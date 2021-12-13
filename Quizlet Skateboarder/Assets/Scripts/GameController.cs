using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timertext;
    public float remaining_time = 100f;
    public string wordInQuestion1 = "space";
    public string wordInQuestion2 = "space";
    public string player1spelling;
    public string player2spelling;

    private void Start()
    {
        StartCoroutine("Countdown");
    }
    private void Update()
    {
        timertext.text = remaining_time.ToString();
    }














    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        remaining_time -= 1f;
        StartCoroutine("Countdown");
    }
}
