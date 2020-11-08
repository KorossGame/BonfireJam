using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject Door;

    void Awake()
    {
        Door = gameObject.transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Destroy(Door);
            Destroy(gameObject);
        }
    }
}
