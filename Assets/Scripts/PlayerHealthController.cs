using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float MaxHealth = 1.0f;
    
    private float health = 1.0f;
    private CharacterController characterController;
    private PlayerInputController playerInputController;

    private void Start()
    {
        health = MaxHealth;

        characterController = GetComponentInChildren<CharacterController>(); 
        playerInputController = GetComponent<PlayerInputController>();

        characterController.CollidedWithSpikes.AddListener(OnCollidedWithSpikes);
    }

    public void TakeDamage(float damage = 0.2f)
    {

        health -= damage;
        Debug.Log("Player health: " + health);
        // if hp is less than 0, call PlayerDied event
/*         if (health <= 0)
        {
            playerInputController.enabled = false;
            characterController.SetJump(false);
            characterController.SetHorizontal(0);
            characterController.SetVertical(0);
            //characterController.PlayDeathAnimation();
            // TODO: Died event
        } */
    }

    private void OnCollidedWithSpikes()
    {
        TakeDamage();
    }
}