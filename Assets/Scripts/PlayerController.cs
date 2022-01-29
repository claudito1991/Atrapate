using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector3 yOffset;
    [SerializeField] float rayLongitude;
    private Rigidbody2D playerRB;


    private float HorizontalMovement;
    public bool Grounded;

    private void Start()
    {
        playerRB = GetComponentInChildren<Rigidbody2D>();
    }
    private void Update()
    {

        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        Debug.Log($"Horizontal Movement: {HorizontalMovement}");
        GroundedCheck();

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

    }

    private void GroundedCheck()
    {
        Debug.DrawRay(transform.position + yOffset, Vector3.down * rayLongitude, Color.red);
        if (Physics2D.Raycast(transform.position + yOffset, Vector3.down, rayLongitude))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }

    private void Jump()
    {
        playerRB.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(HorizontalMovement * movementSpeed, playerRB.velocity.y);
    }
}
