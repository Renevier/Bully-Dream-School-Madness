using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] Rigidbody rb = null;
    [SerializeField] CapsuleCollider col = null;

    [Header("Stats")]
    [SerializeField] float health = 0f;
    [SerializeField] float speed = 0f;
    [SerializeField] float jumpForce = 0f;
    [SerializeField] LayerMask groundLayer;

    PlayerInput playerInput;

    Vector3 movement;
    bool isJumping = false;
    bool isAttacking = false;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.player.Movement.performed += OnMove;
        playerInput.player.Movement.canceled += OnMove;

        playerInput.player.Jump.performed += OnJump;
        playerInput.player.Jump.canceled += OnJump;

        playerInput.player.Punch.performed += OnPunch;
        playerInput.player.Punch.canceled += OnPunch;
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

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement.x * speed * Time.deltaTime, 0f, movement.z * speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);

        anim.SetBool("isWalking", (movement == Vector3.zero ? false : true));
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        isJumping = ctx.ReadValueAsButton();

        if (IsGrounded() && isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            anim.SetBool("isJumping", true);
        }
        else
            anim.SetBool("isJumping", false);

    }

    private void OnPunch(InputAction.CallbackContext ctx)
    {
        isAttacking = ctx.ReadValueAsButton();

        anim.SetBool("isAttacking", isAttacking);

    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius, groundLayer);
    }

    private void TakeDamage(float _damage)
    {
        health -= _damage;

        //play hurt anim
    }

}
