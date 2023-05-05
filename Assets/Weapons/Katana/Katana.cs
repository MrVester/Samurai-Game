using System.Collections;
using UnityEngine;

public class Katana : Weapon
{
    [Header("Damaging")]
    // private CharacterController characterController;
    public Animator katanaAnimator;
    public new void Start()
    {
        base.Start();
        CharacterParameters.AttackCoolDown = attackCoolDown;
        //characterController = GetComponentInParent<CharacterController>();


    }

    protected override void CallAttack()
    {

        // Attack enemy
        Debug.Log("Attack");

        katanaAnimator.SetTrigger("Attack");
        StartCoroutine(DealDamageCoroutine());
    }



}