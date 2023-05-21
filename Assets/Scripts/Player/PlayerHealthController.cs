using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : HealthController
{

    private CharacterController characterController;
    private PlayerInputController playerInputController;
    public HealthBar healthBar;
    private DamageFlash _damageFlash;

    private new void Start()
    {

        base.Start();
        characterController = GetComponentInChildren<CharacterController>();
        playerInputController = GetComponent<PlayerInputController>();
        healthBar.SetMaxHealth(maxHealth);
        _damageFlash = GetComponent<DamageFlash>();
        /// CharacterEvents.current.onTakeDamage += TakeDamage;
    }

    public override void TakeDamage(float damage)
    {
        //BloodParticles.Play();

        // TODO: Add knockback
        health -= damage;
        // if hp is less than 0, call PlayerDied event


        if (!isDead)
        {
            AudioController.current.PlayHitSound();
            _damageFlash.Flash(Color.white);

        }
        else
        {
            health = 0;
        }
        if (health <= 0 && !isDead)
        {
            health = 0;
            healthBar.SetHealth(0);
            isDead = true;
            PlayerDied();
        }

        else

        if (health > 0 && !isDead)
        {

            healthBar.SetHealth(health);
            Debug.Log("Player health: " + health);
        }
    }

    public void KillCharacter()
    {
        health = 0;
        healthBar.SetHealth(0);
        isDead = true;
        PlayerDied();
    }
    private void PlayerDied()
    {
        CharacterEvents.current.Death();
        playerInputController.enabled = false;
        characterController.SetJump(false);
        characterController.SetHorizontal(0);
        characterController.SetVertical(0);
        // characterController.animator.SetBool("Dead", true);
        characterController.PlayDeathAnimation();
        // TODO: Died event*/
    }

}