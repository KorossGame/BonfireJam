using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool alive;
    public SpriteRenderer visualPlayer;
    public float respawnTime = 2f;
    public Transform savePoint;

    void Start()
    {
        alive = true;
    }

    public void Die()
    {
        alive = false;
        visualPlayer.enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        StartCoroutine(Respawn());
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        alive = true;
        gameObject.transform.position = savePoint.position;
        visualPlayer.enabled = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "enemy")
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "enemy")
        {
            Die();
        }
    }
}
