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
    [SerializeField] private AnimationClip clip;

    PlayerInput playerInput;

    float maxHealth = 10;
    Vector3 movement;
    bool isJumping = false;
    bool isAttacking = false;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.player.Movement.performed += OnMove;
        playerInput.player.Movement.canceled += OnMove;

        playerInput.player.Jump.performed += OnJump;

        playerInput.player.Punch.performed += OnPunch;
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
        if(IsGrounded())
          isJumping = true;

        //fistGo.SetActive(isJumping);

        if (IsGrounded() && isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            anim.SetBool("isJumping", true);
        }
        else
            anim.SetBool("isJumping", false);

        StartCoroutine(AnimCor("isJumping"));

    }

    private void OnPunch(InputAction.CallbackContext ctx)
    {
        isAttacking = true;

        fistGo.SetActive(isAttacking);
        anim.SetBool("isAttacking", isAttacking);

        StartCoroutine(AnimCor("Punch"));

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

    IEnumerator AnimCor(string _action)
    {
        yield return null;
        AnimatorStateInfo animatorStateInfo = anim.GetNextAnimatorStateInfo(0);
        yield return new WaitForSeconds(animatorStateInfo.length - Time.deltaTime);

        if (_action == "Punch")
        {
            isAttacking = false;
            anim.SetBool("isAttacking", isAttacking);
            fistGo.SetActive(isAttacking);
        }
        else if(_action == "isJumping")
        {
            isJumping = false;
            anim.SetBool("isJumping", isJumping);
            //fistGo.SetActive(isJumping);
        }
    }
}
