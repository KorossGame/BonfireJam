using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrap : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float fireRate;
    
    private float nextShootTime;

    public float forwardForce;
    public Vector3 direction;

    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + 1 / fireRate;
            Bullet bullet = Instantiate(bulletPrefab, transform.position + direction, gameObject.transform.rotation, gameObject.transform);
            bullet.rb.AddForce(direction * forwardForce);
            // Play Toaster Sound
            AudioManager.instance.Play("Toaster");
        }
    }
    
}
