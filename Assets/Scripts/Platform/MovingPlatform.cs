using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f;
    public Transform PosA, PosB;

    private Vector3 nextPos;

    void Start()
    {
        nextPos = PosA.position;
    }

    void Update()
    {
        if (transform.position == PosA.position)
        {
            nextPos = PosB.position;
        }
        else if (transform.position == PosB.position)
        {
            nextPos = PosA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(PosA.position, PosB.position);
    }
}
