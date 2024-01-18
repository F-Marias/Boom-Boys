using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            //Effects when projectile hits
            Destroy(gameObject);
            Debug.Log("Projectile hit: " + other.gameObject.name);
        }
    }
}
