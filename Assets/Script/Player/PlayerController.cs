using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform cam = null;
    [SerializeField] Rigidbody rb = null;
    [SerializeField] PlayerData playerData = null;
    [SerializeField] Animator anim = null;

    [Header("Punch")]
    [SerializeField] private GameObject punchGo;
    [SerializeField] private Transform initPunchPos;

    PlayerInput playerInput;

    float health = 0f;
    float energy = 0f;

    bool isAttacking = false;
    bool isTouch = false;
    bool isThrowing = false;

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

        playerInput.player.Pause.performed += OnPause;

    }

    private void OnPause(InputAction.CallbackContext obj) => Time.timeScale = 0.0f;

    private void OnEnable() => playerInput.Enable();

    void Start()
    {
        health = playerData.GetMaxHealth();
        energy = playerData.GetMaxEnergy();
    }

    private void Update()
    {
        anim.SetBool("isIdle", playerData.movement == Vector3.zero && !isAttacking && !isThrowing && !isTouch);

        Mathf.Clamp(health, 0, playerData.GetMaxHealth());

        PlayerRotation();

        ManageEnergy();
        
    }

   

    private void FixedUpdate()
    {
        transform.position += playerData.movement * playerData.GetSpeed() * Time.deltaTime;
    }

    private void OnDisable() => playerInput.Disable();

    private void OnMove(InputAction.CallbackContext ctx)
    {
        playerData.movement = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
        playerData.movement = playerData.movement.x * cam.right.normalized + playerData.movement.z * cam.forward.normalized;
    }

    private void OnPunch(InputAction.CallbackContext ctx)
    {
        isAttacking = ctx.ReadValueAsButton();

        if (isAttacking)
            punchGo.transform.position = initPunchPos.position + transform.forward * playerData.GetPunchDistance();
        else
            punchGo.transform.position = initPunchPos.position;
    }

    private void OnThrow(InputAction.CallbackContext ctx)
    {
        isThrowing = ctx.ReadValueAsButton();
    }

    private void TakeDamage(float _damage)
    {
        health -= _damage;

        isTouch = true;
    }

    //IEnumerator AnimCor(string _action)
    //{
    //    playerInput.player.Movement.Disable();

    //    AnimatorStateInfo animatorStateInfo = anim.GetNextAnimatorStateInfo(0);
    //    yield return new WaitForSeconds(animatorStateInfo.length / 2 - Time.deltaTime);

    //    playerInput.player.Movement.Enable();

    //    if (_action == "Punch")
    //    {
    //        punchGo.SetActive(false);
    //    }
    //    else if (_action == "isTouch")
    //    {
    //        isTouch = false;
    //        anim.SetBool("isTouch", false);
    //    }
    //    else if (_action == "isThrowing")
    //    {
    //        anim.SetBool("isThrowing", false);
    //    }
    //}

    private void PlayerRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = playerData.movement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = playerData.movement.z;

        Quaternion currentRotation = transform.rotation;

        if (playerData.movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, playerData.rotationFactorPerFrame * Time.deltaTime);

        }
    }
    private void ManageEnergy()
    {
        if (isAttacking)
            energy -= playerData.GetEnergyLost() * Time.deltaTime;
        else
            energy += playerData.GetEnergyWin() * Time.deltaTime;

        energy = Mathf.Clamp(energy, 0, playerData.GetMaxEnergy());

        if (energy <= 0)
        {
            punchGo.transform.position = initPunchPos.position;
            isAttacking = false;
        }
    }

    public PlayerData GetPlayerData() => playerData;
    public float GetCurrentLife() => health;
    public float GetCurrentEnergy() => energy;
}
