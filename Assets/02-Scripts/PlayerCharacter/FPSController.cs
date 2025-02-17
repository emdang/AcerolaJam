using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] PlayerInput inputs;
    [SerializeField] InputActionAsset fpsInput;

    private Vector2 moveInput;
    [SerializeField] float speed;

    private Vector3 playerVelocity;
    [SerializeField] bool grounded;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpForce = 2f;

    [SerializeField] Camera cam;
    private Vector2 lookPos;
    private float xRotation = 0f;
    [SerializeField] float xSens = 30f;
    [SerializeField] float ySens = 30f;

    [SerializeField] bool canMove = true;
    bool paused = false;
    public void OnMove(InputValue value)
    {
        //Debug.Log("Moving" + value);
        moveInput = value.Get<Vector2>();
    }

    public void OnJump()
    {
        //Debug.Log("Jumping");
        Jump();
    }

    public void OnLook(InputValue value)
    {
        //Debug.Log("Looking");
        lookPos = value.Get<Vector2>();
    }

    public void OnPause()
    {
        if (!paused)
        {
            canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inputs.SwitchCurrentActionMap("UI");
            paused = true;

        }
    }

    public void OnResume()
    {
        if (paused)
        {
            Debug.Log("Resume FPS");
            canMove = true;
            paused = false;
            inputs.SwitchCurrentActionMap("Main");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {
        grounded = controller.isGrounded;
        if (canMove)
        {
            PlayerMove();
            PlayerLook();
        }
    }

    public void PlayerMove()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = moveInput.x;
        moveDirection.z = moveInput.y;

        controller.Move(transform.TransformDirection(moveDirection * speed * Time.deltaTime));
        playerVelocity.y += gravity * Time.deltaTime;
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (grounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3f * gravity);
        }
    }

    public void PlayerLook()
    {
        xRotation -= (lookPos.y * Time.deltaTime) * ySens;
        xRotation = (Mathf.Clamp(xRotation, -80f, 80f));

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (lookPos.x * Time.deltaTime) * xSens);
    }

    public void EnableMovement()
    {
        inputs.SwitchCurrentActionMap("Main");
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}


