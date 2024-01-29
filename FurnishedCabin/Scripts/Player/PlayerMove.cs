using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float originalHeight;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float stepOffset = 0.7f;

    private CharacterController charController;
    private Vector3 playerVelocity;
    private bool isCrouching = false;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        originalHeight = charController.height;
        charController.stepOffset = stepOffset;
    }

    private void Update()
    {
        PlayerMovement();
        PlayerJumpAndCrouch();
    }



    private void PlayerMovement()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * speed;
        float horizInput = Input.GetAxis(horizontalInputName) * speed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

    private void PlayerJumpAndCrouch()
    {
        if (charController.isGrounded)
        {
            playerVelocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isCrouching = true;
                charController.height = crouchHeight;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                isCrouching = false;
                charController.height = originalHeight;
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!charController.isGrounded && playerVelocity.y > 0 && hit.normal.y < 0.1f)
        {
            playerVelocity.y = 0;
        }
    }
}
