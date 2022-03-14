using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] Transform cam = null;
    [SerializeField] Rigidbody rb = null;

    [Header("Stats")]
    [SerializeField] float health = 0f;
    public float damage = 0f;
    [SerializeField] float speed = 0f;
    [SerializeField] float jumpForce = 0f;

    [SerializeField] private GameObject punchGo;
    [SerializeField] private GameObject proj;

    PlayerInput playerInput;

    float maxHealth = 10;
    bool isAttacking = false;
    bool isTouch = false;
    bool isThrowing = false;
    bool isJumping = false;

    Vector3 movement;
    float rotationFactorPerFrame = 15.0f;
    private bool isPause;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.player.Movement.performed += OnMove;
        playerInput.player.Movement.canceled += OnMove;

        playerInput.player.Punch.performed += OnPunch;
        playerInput.player.Punch.canceled += OnPunch;

        playerInput.player.Throw.performed += OnThrow;
        playerInput.player.Throw.canceled += OnThrow;

        playerInput.player.Jump.performed += OnJump;
        playerInput.player.Jump.canceled += OnJump;

        playerInput.player.Pause.performed += OnPause;

    }

    private void OnPause(InputAction.CallbackContext obj)
    {
        if (isPause)
        {
            isPause = false;
            Time.timeScale = 0.0f;
        }
        else
        {
            isPause = true;
            Time.timeScale = 1.0f;
        }

    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        isJumping = ctx.ReadValueAsButton();

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            anim.SetTrigger("isJumping");
        }
    }

    private void OnEnable() => playerInput.Enable();

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        PlayerRotation();
    }

    private void FixedUpdate()
    {
        transform.position += movement * speed * Time.deltaTime;
    }

    private void OnDisable() => playerInput.Disable();

    private void OnMove(InputAction.CallbackContext ctx)
    {
        movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
        movement = movement.x * cam.right.normalized + movement.z * cam.forward.normalized;

        anim.SetBool("isWalking", movement == Vector3.zero ? false : true);
    }

    private void OnPunch(InputAction.CallbackContext ctx)
    {
        isAttacking = ctx.ReadValueAsButton();
        punchGo.SetActive(true);

        anim.SetBool("isAttacking", isAttacking);

        StartCoroutine(AnimCor("Punch"));

    }

    private void OnThrow(InputAction.CallbackContext ctx)
    {
        isThrowing = ctx.ReadValueAsButton();
        anim.SetBool("isThrowing", isThrowing);

        movement = Vector3.zero;

        StartCoroutine(AnimCor("isThrowing"));
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
        playerInput.player.Movement.Disable();

        AnimatorStateInfo animatorStateInfo = anim.GetNextAnimatorStateInfo(0);
        yield return new WaitForSeconds(animatorStateInfo.length / 2 - Time.deltaTime);

        playerInput.player.Movement.Enable();

        if (_action == "Punch")
        {
            punchGo.SetActive(false);
        }
        else if (_action == "isTouch")
        {
            isTouch = false;
            anim.SetBool("isTouch", false);
        }
        else if (_action == "isThrowing")
        {
            anim.SetBool("isThrowing", false);
        }
    }

    private void PlayerRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = movement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = movement.z;

        Quaternion currentRotation = transform.rotation;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);

        }
    }
}
