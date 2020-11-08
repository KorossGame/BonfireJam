using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float levelTime = 60f;
    public float currentTime = 0f;
    public bool stopTimer = false;

    public TemperatureScript temperature;

    void Start()
    {
        temperature = GameObject.FindGameObjectWithTag("healthbar").GetComponent<TemperatureScript>();
        temperature.SetMaxHealth(levelTime);
    }

    void FixedUpdate()
    {
        if (!temperature)
        {
            temperature = GameObject.FindGameObjectWithTag("healthbar").GetComponent<TemperatureScript>();
        }

        if (levelTime - currentTime <= 0)
        {
            GameManager.instance.player.GetComponent<Player>().Die();
        }
        else if (!stopTimer)
        {
            currentTime += Time.fixedDeltaTime;
            temperature.SetHealth(levelTime - currentTime);
        }
    }
}
