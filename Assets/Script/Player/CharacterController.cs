using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator anim = null;

    [Header("Stats")]
    [SerializeField] float health = 0f;
    public float damage = 0f;
    [SerializeField] float speed = 0f;

    [SerializeField] private GameObject punchGo;
    [SerializeField] private GameObject proj;

    PlayerInput playerInput;

    float maxHealth = 10;
    bool isAttacking = false;
    bool isTouch = false;
    bool isThrowing = false;

    Vector3 movement;

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.player.Movement.performed += OnMove;
        playerInput.player.Movement.canceled += OnMove;

        playerInput.player.Punch.performed += OnPunch;
        playerInput.player.Punch.canceled += OnPunch;

        playerInput.player.Throw.performed += OnThrow;

    }

    private void OnEnable() => playerInput.Enable();

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement.x * speed * Time.deltaTime, 0f, movement.z * speed * Time.deltaTime);
    }

    private void OnDisable() => playerInput.Disable();

    private void OnMove(InputAction.CallbackContext ctx)
    {
        movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);

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
}
