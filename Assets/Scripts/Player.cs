using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Alive flag
    public bool alive;

    // Respawn time and save point
    public float respawnTime = 1f;
    public Transform savePoint;
    
    // Timer
    private Timer timerObject;

    // Animator
    public Animator animator;

    void Start()
    {
        alive = true;
        animator = GetComponent<Animator>();
        timerObject = GameObject.FindGameObjectWithTag("timer").GetComponent<Timer>();
    }

    public void Die()
    {
        if (alive)
        {
            if (timerObject)
            {
                // Stop level timer
                timerObject.stopTimer = true;
            }

            // Set alive flag to false
            alive = false;


            // Play Death Animation
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Dead1");

            // Play Death Sound
            AudioManager.instance.Play("Die");

            // Reset physics last velocity vector
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            // Disable physics
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<Rigidbody2D>().simulated = false;

            // Call respawn function
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn()
    {
        // Wait for few seconds for respawn
        yield return new WaitForSeconds(respawnTime);

        // Reset the animation
        animator.ResetTrigger("Dead1");
        animator.SetTrigger("Idle");

        // Set alive flag to true
        alive = true;
        
        // Teleport to save point
        gameObject.transform.position = savePoint.position;
        
        // Enable physics
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;

        // Reset level timer
        if (timerObject)
        {
            timerObject.stopTimer = false;
            timerObject.currentTime = 0f;
            timerObject.temperature.SetHealth(timerObject.levelTime);
        }
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
        else if (col.transform.tag == "Finish")
        {
            // Play Finish Level Sound
            AudioManager.instance.Play("FinishLevel");
            if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings-1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
