using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallMovement : MonoBehaviour
{

    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Starts = true;

    private int hitCounter = 0;

    private Rigidbody2D rb;

    private TrailToggle trail;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponentInChildren<TrailToggle>();

        StartCoroutine(Launch());
    }
    private void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
    private static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
    public IEnumerator Launch()
    {
        RestartBall(); 
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        trail.TrailOn();

        if(player1Starts)
        {
            MoveBall(new Vector2(-1, NextFloat(-1,1)));
        }
        else
        {
            MoveBall(new Vector2(1, NextFloat(-1, 1)));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if( hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
