using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    private int hits = 0;

    private void checkHits()
    {
        if(transform.localScale.y > 0.6f && hits % 8 == 0)
        {
            transform.localScale -= new Vector3(0, 0.05f, 0);
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
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");

        racketDirection = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate() // Update physics
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
