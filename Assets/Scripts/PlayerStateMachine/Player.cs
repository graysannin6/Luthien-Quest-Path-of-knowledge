using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    [Header("Attack details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = .2f;

    public bool isBusy { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    private bool isDoubleJumpingAllowed = true;
    public bool isDoubleJumping = false;

    [Header("Dash info")]
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }

    public SkillManager skill { get; private set; }
    [SerializeField] private DashSkill dashSkill;

    [SerializeField] public PotionThrowSkill potionThrowSkill;

    [SerializeField] private DoubleJumpSkill doubleJumpSkill;

    [SerializeField] public ParrySkill parrySkill;

    [SerializeField] public Transform handPosition;

    [SerializeField] public Inventory inventory;

    [SerializeField] public StatsControl statsControl;

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    public PlayerCounterAttackState counterAttack { get; private set; }
    public PlayerAimPotionState aimPotionState { get; private set; }
    public PlayerAirAttackState airAttackState { get; private set; }
    public PlayerAirHeavyAttackState airHeavyAttackState { get; private set; }
    public PlayerAirHeavyAttackGroundState airHeavyAttackGroundState { get; private set; }
    public PlayerDeathState deathState { get; private set; }
    #endregion

    private RippleEffect rippleEffect;
    public bool isDying;

    protected override void Awake()
    {
        base.Awake();
        rippleEffect = GetComponent<RippleEffect>();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");

        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttack = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
        airAttackState = new PlayerAirAttackState(this, stateMachine, "AirAttack");
        airHeavyAttackState = new PlayerAirHeavyAttackState(this, stateMachine, "AirHeavyAttack");
        airHeavyAttackGroundState = new PlayerAirHeavyAttackGroundState(this, stateMachine, "AttackGround");

        aimPotionState = new PlayerAimPotionState(this, stateMachine, "Aim");

        deathState = new PlayerDeathState(this, stateMachine, "IsDying");

        health = 25;
        damage = 50;
    }

    protected override void Start()
    {
        base.Start();

        skill = SkillManager.instance;

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
        CheckForDashInput();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {
        if (isWallDetected())
            return;

        if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dash.CanUseSkill() && dashSkill.dashUnlocked)
        {
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;
            //rippleEffect.Emit(Camera.main.WorldToViewportPoint(transform.position));
            stateMachine.ChangeState(dashState);
        }
    }

    public void DoubleJump()
    {
        if (!doubleJumpSkill.doubleJumpUnlocked)
            return;
        if (Input.GetKeyDown(KeyCode.Space) && !isDoubleJumping)
        {
            isDoubleJumping = true;
            stateMachine.ChangeState(jumpState);
        }
    }

    public void Die()
    {
        if (!isDying)
            stateMachine.ChangeState(deathState);

    }

    public void updateHealthBar(int damage)
    {
        statsControl.IncreaseHP(damage);
    }

}
