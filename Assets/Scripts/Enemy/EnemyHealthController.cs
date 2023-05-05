using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float MaxHealth = 10.0f;
    [SerializeField]
    private float health;

    private void Start()
    {
        health = MaxHealth;
    }
    public void TakeDamage(float damage)
    {
        //BloodParticles.Play();

        // TODO: Add knockback
        health -= damage;
        Debug.Log("Enemy health: " + health);
        // if hp is less than 0, call EnemyDied event
        /*         if (health <= 0)
                {
                  EnemyDied();
                } */

    }
    // Update is called once per frame
    void Update()
    {

    }
}
