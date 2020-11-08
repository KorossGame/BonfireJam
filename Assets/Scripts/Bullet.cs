using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private int destroyTime = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag != "ground")
        {
            Destroy(gameObject);
        }
    }
}
