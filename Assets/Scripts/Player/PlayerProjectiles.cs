using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab;    
    public float projectileSpeed = 10f;    
    public float cooldownDuration = 2f;    
    public float projectileDuration = 3f;  

    private float cooldownTimer = 0f;      

    public PlayerAttack playerAttackScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer <= 0f)
        {
            Throw();
        }

        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void Throw()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        if (projectileRb != null)
        {
            if (playerAttackScript.isLookingLeft == true)
            {
                projectileRb.velocity = new Vector2(projectileSpeed, 0f);
            }else
            {
                projectileRb.velocity = new Vector2(-projectileSpeed, 0f);
            }
            
        }

        Collider2D projectileCollider = projectile.GetComponent<Collider2D>();
        if (projectileCollider != null)
        {
            projectileCollider.isTrigger = true;
        }

        Destroy(projectile, projectileDuration);

        cooldownTimer = cooldownDuration;
    }

    
}
