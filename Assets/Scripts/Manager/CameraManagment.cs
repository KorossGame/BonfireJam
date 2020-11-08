using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagment : MonoBehaviour
{
    private GameObject target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        target = GameManager.instance.player;
    }

    void FixedUpdate()
    {
        Vector3 positionToGo = target.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, positionToGo, smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPos;
    }

}
