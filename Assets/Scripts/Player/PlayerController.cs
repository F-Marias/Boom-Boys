using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput;
    private GameObject camera;
    private CameraFollow camfollow;
    
    private void Start() //temp player find for the camera follow script
    {
        camera = GameObject.Find("Main Camera");
        camfollow = camera.GetComponent<CameraFollow>();
        camfollow.FillTransList(transform);
    }

    private void Update()
    {
        // Only use the horizontal input for movement
        Vector2 movement = movementInput;

        // Normalize the movement vector to ensure consistent speed in both directions
        movement.Normalize();

        // Translate the position based on the horizontal input
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
