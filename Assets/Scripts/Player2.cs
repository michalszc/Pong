using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player2 : MonoBehaviour
{
    public bool isPC = false;
    public float racketSpeed;
    public GameObject ball;

    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 racketDirection;
    private float maxRacketSpeedPC;

    private int hits = 0;

    private void checkHits()
    {
        if ( transform.localScale.y > 0.6f && hits % 8 == 0 )
        {
            transform.localScale -= new Vector3(0, 0.05f, 0);
            maxRacketSpeedPC *= 1.05f;
        }
    }

    public void addHit()
    {
        hits++;
        checkHits();
    }
    public void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        maxRacketSpeedPC = racketSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float directionY;
        if (isPC)
        {   
            if (ball.transform.position.y > transform.position.y + col.bounds.size.y/2)
            {
                directionY = 1f;
            }
            else if (ball.transform.position.y < transform.position.y - col.bounds.size.y/2)
            {
                directionY = -1f;
            }
            else
            {
                directionY = 0f;
            }
            if(directionY != 0 && directionY != racketDirection.y)
            {
                float distance = Math.Abs(ball.transform.position.y - transform.position.y);
                racketSpeed = (maxRacketSpeedPC * distance) / 3.6f;
            }
        }
        else
        {
            directionY = Input.GetAxisRaw("Vertical2");
        }
        racketDirection = new Vector2(0, directionY).normalized;
    }
        
    private void FixedUpdate() // Update physics
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
