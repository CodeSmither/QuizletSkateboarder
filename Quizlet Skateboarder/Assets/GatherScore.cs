using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatherScore : MonoBehaviour
{
    private GameController GameController;
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public Text Player1BonusText;
    public Text Player2BonusText;
    public Text Player1Grade;
    public Text Player2Grade;
    private float Player1FullScore;
    private float Player2FullScore;

    private void Awake()
    {
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        Player1ScoreText = GameController.Player1ScoreText;
        Player2ScoreText = GameController.Player2ScoreText;
        Player1BonusText.text = GameController.player1Bonus.ToString();
        Player2BonusText.text = GameController.player2Bonus.ToString();
        Player1FullScore = GameController.player1Score + GameController.player1Bonus;
        Player2FullScore = GameController.player2Score + GameController.player2Bonus;
    }

    private void GradingSystem()
    {
        if (Player1FullScore > Player2FullScore)
        {
            Player1Grade.text = "A";
            Player2Grade.text = "F";
        }
        else if (Player1FullScore < Player2FullScore)
        {
            Player1Grade.text = "F";
            Player2Grade.text = "A";
        }
        else if (Player1FullScore == Player2FullScore)
        {
            Player1Grade.text = "C";
            Player2Grade.text = "C";
        }
    }

}
