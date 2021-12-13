using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timertext;
    public Text Player1ScoreText;
    public float remaining_time = 100f;
    public string wordInQuestion1 = "space";
    public string wordInQuestion2 = "space";
    public string player1spelling;
    public string player2spelling;
    public int player1Score;
    public int player2Score;
    public bool roundOver;
    

    private void Start()
    {
        StartCoroutine("Countdown");
        
    }
    private void Update()
    {
        timertext.text = remaining_time.ToString();
        Player1ScoreText.text = player1Score.ToString();
    }

    public void WordChecking1()
    {   int x = player1spelling.Length + -1;
        char newestLetter = player1spelling[x];
        if(wordInQuestion1[x] != newestLetter)
        {
            player1Score += (player1spelling.Length / wordInQuestion1.Length) * 50;
            player1spelling = "";
        }
        else if (x + 1 == wordInQuestion1.Length)
        {
            player1Score += 100;
            player1spelling = "";
        }
    }
    public void WordChecking2()
    {

    }
    private void SelectNewWord()
    {

    }
    IEnumerator Countdown()
    {
        if (remaining_time < 0f)
        {
            yield return new WaitForSeconds(1f);
            remaining_time -= 1f;
            StartCoroutine("Countdown");
        }
        if (remaining_time == 0f) ;
        {
            roundOver = true;
        }
    }
}
