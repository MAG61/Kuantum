using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    float speed;
    public float normalSpeed = 6f;
    public float runSpeed = 10f;
    public float crouchSpeed = 3f;
    public float jumpHeight = 3f;
    public float gravity = -20f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isRunning;
    bool isCrouching;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            isRunning = true;
        } else
        {
            isRunning = false;
        }

        if (Input.GetKey(KeyCode.LeftControl) && !isRunning)
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if (isRunning)
        {
            speed = runSpeed;
        }
        else if (isCrouching)
        {
            speed = crouchSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        if (isCrouching)
        {
            gameObject.transform.localScale = new Vector3(1.0f, 0.75f, 1.0f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1.0f, 1.25f, 1.0f);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
