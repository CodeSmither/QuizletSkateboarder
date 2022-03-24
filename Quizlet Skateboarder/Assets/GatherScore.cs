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
        GameController = GameObject.Find("GameManger").GetComponent<GameController>();
    }

    private void FixedUpdate()
    {
        Player1ScoreText.text = "Score: \r\n ".ToString() + GameController.player1Score.ToString();
        Player2ScoreText.text = "Score: \r\n ".ToString() + GameController.player2Score.ToString();
        Player1BonusText.text = "Bonus Points: \r\n ".ToString() + GameController.player1Bonus.ToString();
        Player2BonusText.text = "Bonus Points: \r\n ".ToString() + GameController.player2Bonus.ToString();
        Player1FullScore = GameController.player1Score + GameController.player1Bonus;
        Player2FullScore = GameController.player2Score + GameController.player2Bonus;
        GradingSystem();
    }

    private void GradingSystem()
    {
        if (Player1FullScore > Player2FullScore)
        {
            Player1Grade.text = "Grade: \r\n A";
            Player2Grade.text = "Grade: \r\n F";
        }
        else if (Player1FullScore < Player2FullScore)
        {
            Player1Grade.text = "Grade: \r\n F";
            Player2Grade.text = "Grade: \r\n A";
        }
        else if (Player1FullScore == Player2FullScore)
        {
            Player1Grade.text = "Grade: \r\n C";
            Player2Grade.text = "Grade: \r\n C";
        }
    }

}
