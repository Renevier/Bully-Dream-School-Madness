using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody rb = null;
    [SerializeField] CapsuleCollider col = null;

    [SerializeField] float speed = 0f;
    [SerializeField] float jumpForce = 0f;
    [SerializeField] LayerMask groundLayer;

    PlayerInput playerInput;

    Vector3 movement;
    bool isJumping = false;
    bool isGrounded = false;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.player.Movement.performed += OnMove;
        playerInput.player.Movement.canceled += OnMove;

        playerInput.player.Jump.performed += OnJump;
        playerInput.player.Jump.canceled += OnJump;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (isJumping && IsGrounded())
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        rb.AddForce(movement * speed * Time.deltaTime);
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
    }
    private void OnJump(InputAction.CallbackContext ctx)
    {
        isJumping = ctx.ReadValueAsButton();        
    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius, groundLayer);
    }
}
