using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f;
    public float attackCooldown = 0.5f;

    private bool isAttacking = false;
    private PlayerBlock hitBlockScript;

    public GameObject attackPointer;
    public bool isLookingLeft = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // Upward attack
                Attack(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                // Downward attack
                Attack(Vector2.down);
            }
            else
            {
                // Forward attack
                if(isLookingLeft)
                {
                    Attack(Vector2.right);
                }
                else
                {
                    Attack(Vector2.left);
                }
            }

            StartCoroutine(AttackCooldown());
        }

        SetDirection();
        
    }

    void Attack(Vector2 direction)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(attackPoint.position, direction, attackRange);

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject != gameObject)
            {
                hitBlockScript = hit.collider.GetComponent<PlayerBlock>();
                if(hitBlockScript != null)
                {
                    if (hitBlockScript.isBlocking == false)
                    {
                        // Effects when player is hit
                        Debug.Log("Hit: " + hit.collider.gameObject.name);
                    }
                    else
                    {
                        // Effects when hit is blocked
                        Debug.Log("Blocked: " + hit.collider.gameObject.name);
                    }
                    hitBlockScript = null;
                }
                
            }
        }
    }

    void SetDirection()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isLookingLeft = false;
            attackPointer.transform.localPosition = new Vector2(-0.36f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            isLookingLeft = true;
            attackPointer.transform.localPosition = new Vector2(0.36f, 0);
        }
    }

    IEnumerator AttackCooldown()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
