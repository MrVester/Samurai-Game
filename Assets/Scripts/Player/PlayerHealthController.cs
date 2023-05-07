using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : HealthController
{

    private CharacterController characterController;
    private PlayerInputController playerInputController;

    private new void Start()
    {

        base.Start();
        characterController = GetComponentInChildren<CharacterController>();
        playerInputController = GetComponent<PlayerInputController>();
        /// CharacterEvents.current.onTakeDamage += TakeDamage;
    }

    public override void TakeDamage(float damage)
    {
        //BloodParticles.Play();

        // TODO: Add knockback
        health -= damage;
        // if hp is less than 0, call PlayerDied event
        if (health <= 0 && !isDead)
        {
            isDead = true;
            PlayerDied();
        }

        else

        if (health > 0 && !isDead)
        {

            Debug.Log("Player health: " + health);
        }
    }
    private void PlayerDied()
    {
        CharacterEvents.current.Death();
        playerInputController.enabled = false;
        characterController.SetJump(false);
        characterController.SetHorizontal(0);
        characterController.SetVertical(0);
        characterController.animator.SetBool("Dead", true);
        characterController.PlayDeathAnimation();
        // TODO: Died event*/
    }

}