using System.Collections;
using UnityEngine;

public class Katana : Weapon
{
    [Header("Damaging")]
    // private CharacterController characterController;
    private Animator characterAnimator;

    private new void Start()
    {

        base.Start();
        characterAnimator = transform.root.GetComponent<Animator>();
        CharacterParameters.AttackCoolDown = attackCoolDown;

    }
    public void Awake()
    {


    }

    protected override void CallAttack()
    {

        // Attack enemy
        AudioController.current.PlayPlayerAttackSound();
        Debug.Log("Attack");

        characterAnimator.SetTrigger("Attack");

    }



}