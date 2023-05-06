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
        CharacterParameters.AttackCoolDown = attackCoolDown;
        //characterController = GetComponentInParent<CharacterController>();


    }

    protected override void CallAttack()
    {

        // Attack enemy
        Debug.Log("Enemy Attack");


    }
}
