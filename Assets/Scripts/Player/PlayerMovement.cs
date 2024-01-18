using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private void Update()
    //{
    //    Vector2 movement = Vector2.zero;
    //    if (tag == "Player1")
    //    {
    //        // Player 1 controls with WASD
    //        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    //    }
    //    else if (tag == "Player2")
    //    {
    //        // Player 2 controls with arrow keys
    //        movement = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
    //    }
    //    else if (tag == "Player3")
    //    {
    //        movement = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
    //    }
    //    Vector2 velocity = movement.normalized * speed;
    //    rb.velocity = velocity;
    //}

    public float moveSpeed = 5f; // Adjust this value to control the movement speed
    public float jumpForce = 10f; // Adjust this value to control the jump force
    public Transform groundCheck; // Drag a GameObject representing the ground to this field in the Inspector
    public LayerMask groundLayer; // Set this to the ground layer in the Inspector

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        MovePlayer(movement);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void MovePlayer(Vector2 movement)
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
