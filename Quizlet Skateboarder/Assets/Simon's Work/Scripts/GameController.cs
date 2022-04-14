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
    public string wordInQuestion1 = "SPACE";
    public string wordInQuestion2 = "SPACE";
    // Each players word that they have to spell
    public string player1spelling;
    public string player2spelling;
    // Each players word current spelling of the world
    public float player1Score;
    public float player2Score;
    public float player1Bonus;
    public float player2Bonus;
    // Each players current score
    public bool roundStarted;
    private bool roundOver;
    private bool PreRound = true;
    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject CanvasPosition;
    private Vector3 Startorigin;
    private Vector3 Endpoint;
    private float lerpTime;
    private float elapsedTime;
    private float distance;
    private GameObject StartCanvas;
    private GameObject Camera4;
    private GameObject CountDownTimer;
    private SkateboardController SkateboardController;
    private bool EndGame;
    private Camera MainCamera;
    private Camera EndCamera;
    private BasicUIScripts basicUIScripts;
    private bool unnotified;
    AIThought aIThought;

    public bool RoundOver
    {
        get { return roundOver;}
        set
        {
            roundOver = value;
            if (roundOver == true)
            {
                PostRoundCutScene();
            }
        }
    }
    

    
    // Checks if the round is currently over
    public GameObject[] Nodes;
    // stores all nodes needed
    DictonaryStorage dictonaryStorage;
    [SerializeField] string DictonaryFile;
    public Text currentdefinition;
    private string defstring;

    private void Awake()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        EndCamera = GameObject.Find("End Camera").GetComponent<Camera>();
        MainCamera.enabled = true;
        EndCamera.enabled = false;
        roundStarted = false;
        RoundOver = false;
        SkateboardController = GameObject.Find("Board").GetComponent<SkateboardController>();
        StartCanvas = GameObject.Find("StartCanvas");
        Camera4 = GameObject.Find("Camera4");
        CountDownTimer = GameObject.Find("CountDownTimer");
        CountDownTimer.SetActive(false);
        PreRoundCutScene();
        unnotified = true;
        basicUIScripts = GameObject.Find("End Camera").GetComponent<BasicUIScripts>();
        aIThought = GameObject.Find("AI Board").GetComponent<AIThought>();
    }

    private void FixedUpdate()
    {
        
        if (PreRound == true)
        {
            StartScreen.transform.position = Vector3.Lerp(Startorigin, Endpoint, elapsedTime / lerpTime);
            elapsedTime += Time.deltaTime;
            distance = Vector3.Distance(StartScreen.transform.position, Endpoint);
        }
        if (distance < 0.01f && PreRound == true)
        {
            PreRound = false;
            StartCoroutine(FinishPreRoundCutScene());
        }
        if (remaining_time == 3f)
        {
            //Debug.Log("Detecting End Time");
            if (unnotified == true)
            {
                StartCoroutine(CountToFinish());
                unnotified = false;
            }
            
        }
    }

    private IEnumerator FinishPreRoundCutScene()
    {
        yield return new WaitForSeconds(3);
        Destroy(StartCanvas);
        Destroy(Camera4);
        StartCoroutine(CountToStart());
    }

    private IEnumerator CountToStart()
    {
        CountDownTimer.SetActive(true);
        yield return new WaitForSeconds(3);
        roundStarted = true;
        RoundStart();
        yield return new WaitForSeconds(1);
        CountDownTimer.SetActive(false);
    }
    

    private void PreRoundCutScene()
    {
        Startorigin = StartScreen.transform.position;
        Endpoint = new Vector3(StartScreen.transform.position.x, StartScreen.transform.position.y, CanvasPosition.transform.position.z);
        lerpTime = 1.0f;
        elapsedTime = 0f;
        distance = Vector3.Distance(StartScreen.transform.position, Endpoint);
        if (distance > 0.1f)
        {
            PreRound = true;
        }
        
        
    }

    private IEnumerator CountToFinish()
    {
        CountDownTimer.SetActive(true);
        yield return new WaitForSeconds(3);
        roundOver = true;
        PostRoundCutScene();
        yield return new WaitForSeconds(10);
        basicUIScripts.StartGame();
    }

    private void PostRoundCutScene()
    {
        MainCamera.enabled = false;
        EndCamera.enabled = true;
        
    }


    private void RoundStart()
    {
        dictonaryStorage = new DictonaryStorage(DictonaryFile);
        dictonaryStorage.OrginizeDictionary();
        StartCoroutine("Countdown");
        SelectNewWord();
        StartCoroutine("UpdateAI");
    }

    IEnumerator UpdateAI()
    {
        yield return new WaitForSeconds(1f);
        string Objective = aIThought.Objective;
        Debug.Log(Objective);
        aIThought.CurrentGameObjective = GameObject.Find(Objective);
        
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
        if (wordInQuestion2[x] != newestLetter)
        {
            if (player2spelling.Length > 0)
            {
                float inputscore = 50 / (5 / player2spelling.Length);
                if (inputscore > 10)
                {
                    player2Score += inputscore;
                }
                player2spelling = "";
                
            }
        }
        else if (x + 1 == wordInQuestion2.Length)
        {
            player2Score += 100;
            player2spelling = "";
            
        }
        // checks if the letter used is the correct letter 
        // then checks if the length of the spelled word is the same as the length of the stored word
    }
    private void SelectNewWord()
    {
        //Collect new String 
        
        string tmpWord = RandomDefinition();
        
        wordInQuestion1 = tmpWord;
        wordInQuestion2 = tmpWord;
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
            RoundOver = true;
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
