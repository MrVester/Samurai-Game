using System.Collections;
using UnityEngine;

public class Katana : Weapon
{
    [Header("Damaging")]
    // private CharacterController characterController;
    private Animator characterAnimator;
    public new void Start()
    {
        base.Start();
        characterAnimator = transform.root.GetComponent<Animator>();
        CharacterParameters.AttackCoolDown = attackCoolDown;
        //characterController = GetComponentInParent<CharacterController>();


    }

    protected override void CallAttack()
    {

        // Attack enemy
        Debug.Log("Attack");

        characterAnimator.SetTrigger("Attack");

    }



}