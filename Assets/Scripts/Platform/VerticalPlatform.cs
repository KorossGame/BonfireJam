using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float realWaitTime;
    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        realWaitTime = waitTime;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = realWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0 || Input.GetKeyDown("space"))
        {
            effector.rotationalOffset = 0f;
        }
        else
        {
            waitTime = realWaitTime;
        }
    }
}
