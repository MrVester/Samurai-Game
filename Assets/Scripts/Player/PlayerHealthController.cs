using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float MaxHealth = 10.0f;
    [SerializeField]
    private float health;
    private CharacterController characterController;
    private PlayerInputController playerInputController;

    private void Start()
    {
        health = MaxHealth;

        characterController = GetComponentInChildren<CharacterController>();
        playerInputController = GetComponent<PlayerInputController>();
    }

    public void TakeDamage(float damage)
    {
        //BloodParticles.Play();

        // TODO: Add knockback
        health -= damage;
        Debug.Log("Player health: " + health);
        // if hp is less than 0, call PlayerDied event
        /*         if (health <= 0)
                {
                  PlayerDied();
                } */

    }
    private void PlayerDied()
    {
        /* playerInputController.enabled = false;
         characterController.SetJump(false);
         characterController.SetHorizontal(0);
         characterController.SetVertical(0);
         //characterController.PlayDeathAnimation();
         // TODO: Died event*/
    }

}