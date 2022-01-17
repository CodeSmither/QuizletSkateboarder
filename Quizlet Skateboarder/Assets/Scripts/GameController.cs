using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timertext;
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public float remaining_time = 100f;
    public string wordInQuestion1 = "space";
    public string wordInQuestion2 = "space";
    public string player1spelling;
    public string player2spelling;
    public float player1Score;
    public float player2Score;
    public bool roundOver;
    public GameObject[] Nodes;

    private void Start()
    {
        StartCoroutine("Countdown");
        SelectNewWord();
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
            player1Score += 50/ player1spelling.Length;
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
        int x = player2spelling.Length + -1;
        char newestLetter = player2spelling[x];
        if (wordInQuestion1[x] != newestLetter)
        {
            player2Score += 50 / player2spelling.Length;
            player2spelling = "";
        }
        else if (x + 1 == wordInQuestion1.Length)
        {
            player2Score += 100;
            player2spelling = "";
        }

    }
    private void SelectNewWord()
    {
        //Collect new String

        string tmpWord = "Space".ToUpper();
        char[] tmpWordarray = tmpWord.ToCharArray();
        for (int x = 0; x == 4; x++)
        {
            Nodes[x].name = tmpWordarray[x].ToString();
        }
        
    }
    IEnumerator Countdown()
    {
        if (remaining_time > 0f)
        {
            yield return new WaitForSeconds(1f);
            remaining_time -= 1f;
            StartCoroutine("Countdown");
        }
        if (remaining_time == 0f)
        {
            roundOver = true;
        }
    }
}
