#if ENABLE_INPUT_SYSTEM && ENABLE_INPUT_SYSTEM_PACKAGE
#define USE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

#if USE_INPUT_SYSTEM
    private PlayerInput playerInput;
    private InputAction moveAction;
#else
    private float horizontal;
    private float vertical;
#endif

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

#if USE_INPUT_SYSTEM
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"]; // expects Vector2 input
#endif
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Movement input
        Vector2 input =
#if USE_INPUT_SYSTEM
            moveAction.ReadValue<Vector2>();
#else
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#endif

        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0; // Flatten to ground plane

        // Move character
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Rotate towards movement direction
        if (move.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
