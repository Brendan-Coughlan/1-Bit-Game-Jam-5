using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    private Rigidbody2D playerRb;
    private Vector2 movementInput;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        int horizontalInput = (int)Input.GetAxisRaw("Horizontal");
        int verticalInput = (int)Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(horizontalInput, verticalInput);
        
        playerRb.velocity = movementInput.normalized * walkSpeed;
    }
}
