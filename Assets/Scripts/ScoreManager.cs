using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{   
    public int scoreToReach;

    public Player1 player1;
    public Player2 player2;

    private int player1Score = 0;
    private int player2Score = 0;

    public Text player1ScoreText;
    public Text player2ScoreText;
    
    private void resetPlayers()
    {
        player1.ResetPosition();
        player2.ResetPosition();
    }

    public void player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        resetPlayers();
        CheckScore();
    }
    public void player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        resetPlayers();
        CheckScore();
    }
    private void CheckScore()
    {
        if(player1Score == scoreToReach || player2Score == scoreToReach)
        {
            if (player2.isPC)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
