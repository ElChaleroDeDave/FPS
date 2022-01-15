using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController charactercontroller;

    public float speed = 10f;

    private float gravity = -9.81f;

    public Transform groundCheck;
    public float spheRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    Vector3 velocity;

    public float jumpHeight = 3;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, spheRadius, groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        charactercontroller.Move(move * speed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;

        charactercontroller.Move(velocity * Time.deltaTime);
    }
}
