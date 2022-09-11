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

    public bool isSprinting;

    public float sprintingSpeedMultiplier = 1.5f;

    private float sprintSpeed = 1;

    public float staminaUseAmount = 5;

    private StaminaBar staminaSlider;

    private void Start()
    {
        staminaSlider = FindObjectOfType<StaminaBar>();
    }

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

        JumpCheck();

        RunCheck();

        charactercontroller.Move(move * speed * Time.deltaTime*sprintSpeed);
        
        velocity.y += gravity * Time.deltaTime;

        charactercontroller.Move(velocity * Time.deltaTime);
    }

    public void JumpCheck()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = !isSprinting;

            if (isSprinting==true)
            {
                staminaSlider.UseStamina(staminaUseAmount);

            }
            else
            {
                staminaSlider.UseStamina(0);

            }
        }
        if (isSprinting ==true)
        {
            sprintSpeed = sprintingSpeedMultiplier;

        }
        else
        {
            sprintSpeed = 1;

        }
    }

}
