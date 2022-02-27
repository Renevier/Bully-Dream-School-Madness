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
    public float damage = 0f;
    [SerializeField] float speed = 0f;
    [SerializeField] float jumpForce = 0f;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] private GameObject fistGo;
    [SerializeField] private GameObject kickGo;

    PlayerInput playerInput;

    float maxHealth = 10;
    Vector3 movement;
    bool isJumping = false;
    bool isAttacking = false;
    bool isTouch = false;
    bool isThrowing = false;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.player.Movement.performed += OnMove;
        playerInput.player.Movement.canceled += OnMove;

        playerInput.player.Jump.performed += OnJump;
        playerInput.player.Jump.canceled += OnJump;

        playerInput.player.Punch.performed += OnPunch;

        playerInput.player.Throw.performed += OnThrow;
        playerInput.player.Throw.canceled += OnThrow;
    }   

    private void OnEnable()
    {
        playerInput.Enable();
    }

    void Start()
    {
        health = maxHealth;
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
        isJumping = ctx.ReadValueAsButton(); ;

        kickGo.SetActive(isJumping);

        if (IsGrounded() && isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);

            anim.SetBool("isJumping", true);
            StartCoroutine(AnimCor("isJumping"));
        }
        else if(!IsGrounded())        
            kickGo.SetActive(false);
    }

    private void OnPunch(InputAction.CallbackContext ctx)
    {
        isAttacking = true;

        fistGo.SetActive(isAttacking);
        anim.SetBool("isAttacking", isAttacking);

        StartCoroutine(AnimCor("Punch"));

    }

    private void OnThrow(InputAction.CallbackContext ctx)
    {
        isThrowing = ctx.ReadValueAsButton();
        anim.SetBool("isThrowing", isThrowing);

        StartCoroutine(AnimCor("isThrowing"));
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius, groundLayer);
    }

    private void TakeDamage(float _damage)
    {
        health -= _damage;

        isTouch = true;
        anim.SetBool("isTouch", true);
        StartCoroutine(AnimCor("isTouch"));
    }

    IEnumerator AnimCor(string _action)
    {
        yield return null;
        AnimatorStateInfo animatorStateInfo = anim.GetNextAnimatorStateInfo(0);
        yield return new WaitForSeconds(animatorStateInfo.length - Time.deltaTime);

        if (_action == "Punch")
        {
            isAttacking = false;
            anim.SetBool("isAttacking", false);
            fistGo.SetActive(isAttacking);
        }
        else if (_action == "isJumping")
        {
            anim.SetBool("isJumping", false);
            kickGo.SetActive(false);
        }
        else if( _action == "isTouch")
        {
            isTouch = false;
            anim.SetBool("isTouch", false);
        }
        else if (_action == "isThrowing")
        {
            anim.SetBool("isThrowing", false);
        }
    }
}
