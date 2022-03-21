using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DictonaryConverter;

public class GameController : MonoBehaviour
{
    public Text timertext;
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public Text Player1SpellingText;
    public Text Player2SpellingText;
    // Different text settings for the UI;
    public float remaining_time = 100f;
    // Remaining Time in the round
    public string wordInQuestion1 = "space";
    public string wordInQuestion2 = "space";
    // Each players word that they have to spell
    public string player1spelling;
    public string player2spelling;
    // Each players word current spelling of the world
    public float player1Score;
    public float player2Score;
    // Each players current score
    public bool roundOver;
    // Checks if the round is currently over
    public GameObject[] Nodes;
    // stores all nodes needed
    DictonaryStorage dictonaryStorage;
    [SerializeField] string DictonaryFile;
    public Text currentdefinition;
    private string defstring;

    private void Awake()
    {
        dictonaryStorage = new DictonaryStorage(DictonaryFile);
        dictonaryStorage.OrginizeDictionary();
        StartCoroutine("Countdown");
        SelectNewWord();
        //starts functions and coroutines which need to be checked in seconds rather than frames
    }
    private void Update()
    {
        timertext.text = remaining_time.ToString();
        Player1ScoreText.text = player1Score.ToString();
        Player2ScoreText.text = player2Score.ToString();
        Player1SpellingText.text = player1spelling.ToUpper();
        Player2SpellingText.text = player2spelling.ToUpper();
        currentdefinition.text = defstring;
        // Updates all Text on the UI
    }

    public void WordChecking1()
    {   int x = player1spelling.Length + -1;
        char newestLetter = player1spelling[x];
        // searches for the newest letter in the player spelling
        if(wordInQuestion1[x] != newestLetter)
        {
            if (player1spelling.Length > 0)
            {
                float inputscore = 50 / (5 / player1spelling.Length);
                if (inputscore > 10)
                {
                    player1Score += inputscore;
                }
            }
            player1spelling = "";
            SelectNewWord();
        }
        else if (x + 1 == wordInQuestion1.Length)
        {
            player1Score += 100;
            player1spelling = "";
            SelectNewWord();
        }
        // checks if the letter used is the correct letter 
        // then checks if the length of the spelled word is the same as the length of the stored word
    }
    public void WordChecking2()
    {
        int x = player2spelling.Length + -1;
        char newestLetter = player2spelling[x];
        // searches for the newest letter in the player spelling
        if (wordInQuestion1[x] != newestLetter)
        {
            if (player2spelling.Length > 0)
            {
                float inputscore = 50 / (5 / player2spelling.Length);
                if (inputscore > 10)
                {
                    player2Score += inputscore;
                }
                player2spelling = "";
                SelectNewWord();
            }
        }
        else if (x + 1 == wordInQuestion1.Length)
        {
            player2Score += 100;
            player2spelling = "";
            SelectNewWord();
        }
        // checks if the letter used is the correct letter 
        // then checks if the length of the spelled word is the same as the length of the stored word
    }
    private void SelectNewWord()
    {
        //Collect new String 
        
        string tmpWord = RandomDefinition();
        
        wordInQuestion1 = tmpWord;
        char[] tmpWordarray = WordOrginization.ScrambleWord(tmpWord);
        int x = 0;
        foreach (char character in tmpWordarray)
        {
            //Debug.Log(character);
            Nodes[x].GetComponent<NodeLetter>().letter = character.ToString();
            x++;
        }
        // Makes the string Upper case then randomly distributes each letter between each node
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
        // checks if the round is over or not
    }

    private string RandomDefinition()
    {
        int x = Random.Range(0,dictonaryStorage.ValuesArray.GetLength(1));
        string tmpword = dictonaryStorage.ValuesArray[0, x];
        string tmpdef = dictonaryStorage.ValuesArray[1, x];
        defstring = tmpdef;
        return tmpword;
    }

}
