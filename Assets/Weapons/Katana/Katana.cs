using UnityEngine;

public class Katana : Weapon
{
    [Header("Damaging")]
    private CharacterController characterController;
    private Animator katanaAnimator;

    private void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    protected override void CallAttack()
    {
        // Attack enemy
        Debug.Log("Attack");
    }
}