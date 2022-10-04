using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    public Transform playerBody;

    Animator animator;

    float xRotation = 0f;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (animator.GetBool("isRunning") == false)
            {
                animator.SetBool("isRunning", true);
            }

        }
        else
        {
            if (animator.GetBool("isRunning") == true)
            {
                animator.SetBool("isRunning", false);
            }
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
