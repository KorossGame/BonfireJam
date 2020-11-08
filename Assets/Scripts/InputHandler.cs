using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 jumpDirection;
    public float maxMagnitude = 5f;
    public float jumpVelocity;

    private int maxJumps = 4;
    private int currentJumps = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        jumpDirection = Vector2.ClampMagnitude(direction, maxMagnitude);

        if (Input.GetKeyDown("space") && currentJumps < maxJumps)
        {
            rb.AddForce(jumpDirection * jumpVelocity);
            currentJumps++;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {
            currentJumps = 0;
        }
    }
}
