using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_Wizardo : Enemy
{
    public bool isMoving = false;
    [SerializeField] private WizardAttackPool pool;

    public WizzardAttackState attackState { get; private set; }
    public WizzardMoveState moveState { get; private set; }
    public WizardStunnedState stunnedState { get; private set; }
    public WizzardDyingState dyingState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        //facingDir = -1;
        moveSpeed = 15;
        attackState = new WizzardAttackState(this, stateMachine, "attack");
        moveState = new WizzardMoveState(this, stateMachine, "move");
        stunnedState = new WizardStunnedState(this, stateMachine, "stun");
        dyingState = new WizzardDyingState(this, stateMachine, "die");

        health = 100;
        damage = 5;
    }

    protected override void Start()
    {
        base.Start();
        facingDir = -1;
        facingRight = false;
        stateMachine.Initialize(attackState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public GameObject PoolAttack()
    {
        return pool.GetPooled();
    }

    public void Attack()
    {
        GameObject pool = PoolAttack();
        if (pool != null)
        {
            pool.SetActive(true);
            WizardAttack attack = pool.GetComponent<WizardAttack>();
            Vector3 enemyPos = transform.position;
            Vector3 vector3 = new Vector3(enemyPos.x + (2 * facingDir), enemyPos.y - 0.5f, enemyPos.z);
            attack.SetUpAttack(facingDir, vector3);
        }
    }

    public override void Die()
    {
        if (!isDying)
        {
            stateMachine.ChangeState(dyingState);
            Dissapear();
        }
    }

    public override void Stun()
    {
        stateMachine.ChangeState(stunnedState);
    }

    public override void HandleIncomingAttack(int _damage)
    {
        if (isMoving)
            return;
        Stun();
        if (Damage(_damage))
        {
            Die();
        }
    }
}
