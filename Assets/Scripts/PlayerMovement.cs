using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag; 

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded; 

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection; 

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        horizontalInput = 0;
        verticalInput = 0;  
    }


    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);  

        SpeedControl();
        MyInput();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }


    private void FixedUpdate()
    {
        
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput < 0.9 && horizontalInput > -0.9)
            horizontalInput = 0;

        if (verticalInput < 0.9 && verticalInput > -0.9)
            verticalInput = 0;


        UnityEngine.Debug.Log(horizontalInput + " " + verticalInput);


    }

    private void MovePlayer()
    {

        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);

        
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

       // UnityEngine.Debug.Log(moveDirection);
        
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; 
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
