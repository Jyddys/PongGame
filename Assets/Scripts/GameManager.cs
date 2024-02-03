using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;
    public TextMeshProUGUI winnerText;
    private int _playerScore;
    private int _computerScore;

    private readonly int _maxScore = 2;

    public void PlayerScores()
    {
        _playerScore++;
        playerScoreText.text = _playerScore.ToString();
        ResetRound(playerPaddle);
    }

    public void ComputerScores()
    {
        _computerScore++;
        computerScoreText.text = _computerScore.ToString(); 
        ResetRound(computerPaddle);
    }

    enum Winner
    {
        None,
        Player,
        Computer
    }

    private void ResetRound(Paddle paddle)
    {
        Winner winner = DetermineWinner();
        if (winner != Winner.None) {
         DeclareWinner(winner);
         return;
        }
        paddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    private Winner DetermineWinner()
    {
        if (_computerScore == _maxScore) return Winner.Computer;
        if (_playerScore == _maxScore) return Winner.Player;
        return Winner.None;
    }

    private void DeclareWinner(Winner winner)
    {
        Pause();
        string winnerName = winner == Winner.Computer ? "Computer" : "Player";
        winnerText.text = $"{winnerName} wins the game!";
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}
