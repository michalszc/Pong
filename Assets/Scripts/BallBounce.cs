using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;

    public BallMovement ballMovement;
    public ScoreManager scoreManager;

    private TrailToggle trail;

    public Player1 player1;
    public Player2 player2;

    private void Start()
    {
        trail = GetComponentInChildren<TrailToggle>();
    }
    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector3(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
            
            if(collision.gameObject.name == "Player 1")
            {
                player1.addHit();
                trail.ChangeColor(0, 255, 0);
            }
            else
            {
                player2.addHit();
                trail.ChangeColor(255, 0, 0);
            }
        }
        else if (collision.gameObject.name == "RightBorder") 
        {
            scoreManager.player1Goal();
            ballMovement.player1Starts = false;
            trail.TrailOff();
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "LeftBorder")
        {
            scoreManager.player2Goal();
            ballMovement.player1Starts = true;
            trail.TrailOff();
            StartCoroutine(ballMovement.Launch());
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
