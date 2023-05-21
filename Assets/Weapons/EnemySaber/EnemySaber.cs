using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaber : Weapon
{

    private Animator enemyAnimator;
    public new void Start()
    {
        base.Start();
        enemyAnimator = transform.root.GetComponent<Animator>();
        //characterController = GetComponentInParent<CharacterController>();


    }

    public override void DealDamage()
    {
        base.DealDamage();
        CallAttack();
    }
    protected override void CallAttack()
    {

        // Attack enemy
        AudioController.current.PlayEnemyAttackSound();
        Debug.Log("Enemy Attack");


    }
}
