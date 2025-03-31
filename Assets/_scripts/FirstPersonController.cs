using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;

    private float rotationX = 0;
    private CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.GetChild(0).localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D or Left, Right
        float moveZ = Input.GetAxis("Vertical");   // W, S or Up, Down

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity.y = -2f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}