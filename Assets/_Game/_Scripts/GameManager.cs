using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI player1ScoreText, player2ScoreText;

    [SerializeField]
    private Rigidbody2D ball;

    [SerializeField]
    private Transform paddle1, paddle2;

    [SerializeField]
    private int maxPoints = 10;

    private int player1Score, player2Score;

    void Start()
    {
        ball.gameObject.SetActive(false);
        ShowScore();
        Invoke("ResetGame", 2); //Chama o metodo apos 2 segundos
    }

    private void ResetGame()
    {
        ball.gameObject.SetActive(true);
        ResetBall();

        paddle1.transform.position = new Vector2(paddle1.transform.position.x, 0);
        paddle2.transform.position = new Vector2(paddle2.transform.position.x, 0);

        player1Score = player2Score = 0;

        ShowScore();
    }

    public void ResetBall()
    {
        ball.transform.position = Vector2.zero;
    }

    private void ShowScore()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void AddPointAndVerifyWinner(float ballPositionX)
    {
        ComputePointToTheRightPlayer(ballPositionX);
        ShowScore();
        VerifyWinner();
    }

    private void VerifyWinner()
    {
        if (player1Score >= maxPoints || player2Score >= maxPoints)
        {
            ball.gameObject.SetActive(false);
            Invoke("ResetGame", 3);
        }
    }

    private void ComputePointToTheRightPlayer(float ballPositionX)
    {
        if (ballPositionX > 0)
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }
    }
}
